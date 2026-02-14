# Runtime .NET 10 (preview)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080

# Build .NET 10 (preview)
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia csproj e restaura
COPY ["ApiClientePedidoVideo.csproj", "./"]
RUN dotnet restore "ApiClientePedidoVideo.csproj"

# Copia tudo
COPY . .

# Build
RUN dotnet build "ApiClientePedidoVideo.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ApiClientePedidoVideo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiClientePedidoVideo.dll"]
