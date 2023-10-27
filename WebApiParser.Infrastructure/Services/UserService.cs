using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.IRepositories;
using WebApiParser.Domain.SeedWork;
using WebApiParser.ReferenceParser.DTOs;
using WebApiParser.ReferenceParser.Options;

namespace WebApiParser.Infrastructure.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IOptions<JwtOptions> _options;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IOptions<JwtOptions> options, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _options = options;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var userEntity = await _userRepository.FirstOrDefault(x => x.Id == id);
            if (userEntity == null)
                throw new Exception("Не найден пользователь");
            var userDto = _mapper.Map<User, UserModel>(userEntity);
            return userDto;
        }

        public async Task Registration(RegistrationModel registrationDTo)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = await userRepository.FirstOrDefault(x => x.Mail == registrationDTo.Mail);
            if (user != null)
                throw new Exception("Данный пользователь уже зарегистрирован в системе");
            var userSave = _mapper.Map<RegistrationModel, User>(registrationDTo);
            userSave.Password = BCrypt.Net.BCrypt.HashPassword(userSave.Password, BCrypt.Net.BCrypt.GenerateSalt());
            await userRepository.AddAsync(userSave);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> Authorize(AuthModel authDto)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = await userRepository.FirstOrDefault(x => x.Mail == authDto.Mail);
            if (user == null)
                throw new Exception("Данный пользователь не аутентифицирован в системе");
            if (BCrypt.Net.BCrypt.Verify(authDto.Password, user.Password) == false)
                throw new Exception("Данный пользователь не авторизован в системе");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_options.Value.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Value.Issuer,
                Audience = _options.Value.Audience,
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id", user.Id.ToString()),
                new Claim("mail", user.Mail)
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<string>> GetUserEmails()
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var users = await userRepository.GetAsync();
            var userEmails = users.Select(user => user.Mail).ToList();
            return userEmails;
        }

    }
}
