# Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o csproj e restaura
COPY ["ApiClientePedidoVideo.csproj", "./"]
RUN dotnet restore "ApiClientePedidoVideo.csproj"

# Copia o restante do projeto
COPY . .

# Build
RUN dotnet build "ApiClientePedidoVideo.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ApiClientePedidoVideo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem fin
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiClientePedidoVideo.dll"]
