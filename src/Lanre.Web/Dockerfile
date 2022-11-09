#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV DOTNET_RUNNING_IN_CONTAINER=true
RUN apk add --no-cache icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM node:18-alpine AS build-node
WORKDIR /app
COPY ["src/Lanre.Web/clientapp/package.json", "./package.json"]
RUN npm i
COPY ["src/Lanre.Web/clientapp/", "./"]
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["src/Lanre.Web/Lanre.Web.csproj", "src/Lanre.Web/"]
COPY ["src/Lanre.Infrastructure/Lanre.Infrastructure.csproj", "src/Lanre.Infrastructure/"]
COPY ["src/Lanre.Module.Library/Lanre.Module.Library.csproj", "src/Lanre.Module.Library/"]
COPY ["src/Lanre.Module.Poll/Lanre.Module.Poll.csproj", "src/Lanre.Module.Poll/"]
RUN dotnet restore "src/Lanre.Web/Lanre.Web.csproj"
COPY . .
WORKDIR "/src/src/Lanre.Web"
RUN dotnet build "Lanre.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lanre.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/certs/devcert.pfx /root/.aspnet/https/devcert.pfx 
RUN chmod 644 /root/.aspnet/https/devcert.pfx && update-ca-certificates
COPY --from=publish /app/publish .
COPY --from=build-node /app/build/ ./wwwroot
ENTRYPOINT ["dotnet", "Lanre.Web.dll"]
