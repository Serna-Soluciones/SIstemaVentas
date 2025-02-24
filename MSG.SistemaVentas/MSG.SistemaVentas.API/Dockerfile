# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MSG.SistemaVentas.sln ./
COPY MSG.SistemaVentas.API/MSG.SistemaVentas.API.csproj MSG.SistemaVentas.API/
COPY MSG.SistemaVentas.Application/MSG.SistemaVentas.Application.csproj MSG.SistemaVentas.Application/
COPY MSG.SistemaVentas.Domain/MSG.SistemaVentas.Domain.csproj MSG.SistemaVentas.Domain/
COPY MSG.SistemaVentas.Infrastructure/MSG.SistemaVentas.Infrastructure.csproj MSG.SistemaVentas.Infrastructure/

RUN dotnet restore "./MSG.SistemaVentas.sln"

COPY . .
WORKDIR "/src"

ARG BUILD_CONFIGURATION=Debug
ENV BUILD_CONFIGURATION=$BUILD_CONFIGURATION

RUN dotnet build "./MSG.SistemaVentas.API/MSG.SistemaVentas.API.csproj" --configuration "$BUILD_CONFIGURATION" --output /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MSG.SistemaVentas.API/MSG.SistemaVentas.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSG.SistemaVentas.API.dll"]