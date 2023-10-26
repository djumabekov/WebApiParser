using Microsoft.EntityFrameworkCore;
using WebApiParser.Infrastructure;
using WebApiParser.ReferenceParser.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApiParser.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connection);
});

builder.Services.Configure<ReferenceApiOption>(builder.Configuration.GetSection("ReferencesApi"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCommonServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "JWT",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var migrations = await context.Database.GetPendingMigrationsAsync();
        if (migrations.ToList().Count != 0)
        {
            await context.Database.MigrateAsync();
        }
    }
}

app.Use(async (context, next) =>
{
    var httpContextService = context.RequestServices.GetRequiredService<IContextService>() as HttpContextService;
    var userService = context.RequestServices.GetRequiredService<UserService>();

    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    var userId = httpContextService.ValidateToken(token);
    if (userId != null && Guid.Empty != userId)
    {
        var user = await userService.GetUserById((Guid)userId);
        httpContextService.CurrentUser = user;
    }
    await next(context);
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
