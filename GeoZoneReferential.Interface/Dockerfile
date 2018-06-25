FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY GeoZoneReferential.Interface/GeoZoneReferential.Interface.csproj GeoZoneReferential.Interface/
COPY GeoZoneReferential.Infrastructure/GeoZoneReferential.Infrastructure.csproj GeoZoneReferential.Infrastructure/
COPY GeoZoneReferential.Domain/GeoZoneReferential.Domain.csproj GeoZoneReferential.Domain/
RUN dotnet restore GeoZoneReferential.Interface/GeoZoneReferential.Interface.csproj
COPY . .
WORKDIR /src/GeoZoneReferential.Interface
RUN dotnet build GeoZoneReferential.Interface.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GeoZoneReferential.Interface.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GeoZoneReferential.Interface.dll"]
