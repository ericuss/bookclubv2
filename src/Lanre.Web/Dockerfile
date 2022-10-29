#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Lanre.Web/Lanre.Web.csproj", "src/Lanre.Web/"]
COPY ["src/Lanre.Infrastructure/Lanre.Infrastructure.csproj", "src/Lanre.Infrastructure/"]
COPY ["src/Lanre.Context.Library/Lanre.Context.Library.csproj", "src/Lanre.Context.Library/"]
RUN dotnet restore "src/Lanre.Web/Lanre.Web.csproj"
COPY . .
WORKDIR "/src/src/Lanre.Web"
RUN dotnet build "Lanre.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lanre.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lanre.Web.dll"]
