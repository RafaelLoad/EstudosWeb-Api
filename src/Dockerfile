FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development

FROM base AS build
WORKDIR /workdir
COPY . .

RUN dotnet restore /workdir/Estudos.Services.Api/Estudos.Services.Api.csproj
WORKDIR /workdir/.
RUN dotnet build /workdir/Estudos.Services.Api/Estudos.Services.Api.csproj -c Release -o /workdir/build

FROM build AS publish
RUN dotnet publish /workdir/Estudos.Services.Api/Estudos.Services.Api.csproj -c Release -o /workdir/publish /p:UseAppHost=false

EXPOSE 5000

FROM base AS final
WORKDIR /app
COPY --from=publish /workdir/publish .
ENTRYPOINT ["dotnet", "Estudos.Services.Api.dll"]