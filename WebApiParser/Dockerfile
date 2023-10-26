FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5104

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /usr/local/share/ca-certificates
COPY ["WebApiParser/_.nuget.org.crt", "_.nuget.org.crt"]
RUN chmod 644 _.nuget.org.crt

#RUN /usr/sbin/update-ca-certificates
RUN mkdir -p /etc/ssl/certs/ && update-ca-certificates

WORKDIR /src
COPY ["WebApiParser/WebApiParser.csproj", "WebApiParser/"]
COPY ["WebApiParser.Domain/WebApiParser.Domain.csproj", "WebApiParser.Domain/"]
COPY ["WebApiParser.Infrastructure/WebApiParser.Infrastructure.csproj", "WebApiParser.Infrastructure/"]
COPY ["WebApiParser.ReferenceParser/WebApiParser.ReferenceParser.csproj", "WebApiParser.ReferenceParser/"]
RUN dotnet restore "WebApiParser/WebApiParser.csproj"
COPY . .
WORKDIR "/src/WebApiParser"
RUN dotnet build "WebApiParser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiParser.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiParser.dll"]
