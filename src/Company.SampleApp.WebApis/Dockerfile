#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster AS build
WORKDIR /src
COPY ["src/Company.SampleApp.WebApis/Company.SampleApp.WebApis.csproj", "src/Company.SampleApp.WebApis/"]
COPY ["src/Company.SampleApp.Repositories.Ef/Company.SampleApp.Repositories.Ef.csproj", "src/Company.SampleApp.Repositories.Ef/"]
COPY ["src/Company.SampleApp.Domain.Models/Company.SampleApp.Domain.Models.csproj", "src/Company.SampleApp.Domain.Models/"]
COPY ["src/Company.SampleApp.Domain.Client/Company.SampleApp.Domain.Client.csproj", "src/Company.SampleApp.Domain.Client/"]
COPY ["src/Company.SampleApp.Repositories.Interfaces/Company.SampleApp.Repositories.Interfaces.csproj", "src/Company.SampleApp.Repositories.Interfaces/"]
COPY ["src/Company.SampleApp.Data.Ef/Company.SampleApp.Data.Ef.csproj", "src/Company.SampleApp.Data.Ef/"]
COPY ["src/Company.SampleApp.Services.Core/Company.SampleApp.Services.Core.csproj", "src/Company.SampleApp.Services.Core/"]
COPY ["src/Company.SampleApp.Services.Interfaces/Company.SampleApp.Services.Interfaces.csproj", "src/Company.SampleApp.Services.Interfaces/"]
RUN dotnet restore "src/Company.SampleApp.WebApis/Company.SampleApp.WebApis.csproj"
COPY . .
WORKDIR "/src/src/Company.SampleApp.WebApis"
RUN dotnet build "Company.SampleApp.WebApis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.SampleApp.WebApis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.SampleApp.WebApis.dll"]