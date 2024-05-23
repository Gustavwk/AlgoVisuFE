# Brug Microsofts officielle .NET 7 SDK image til at bygge applikationen
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Kopier csproj og restore som adskilte lag for caching
COPY ["HvorFuckedErJeg2/HvorFuckedErJeg2.WebApi.csproj", "./HvorFuckedErJeg2/"]
RUN dotnet restore "HvorFuckedErJeg2/HvorFuckedErJeg2.WebApi.csproj"

# Kopier resten af kildkoden
COPY HvorFuckedErJeg2/ ./HvorFuckedErJeg2/
WORKDIR /app/HvorFuckedErJeg2
RUN dotnet publish -c Release -o out

# Byg runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/HvorFuckedErJeg2/out .
ENTRYPOINT ["dotnet", "HvorFuckedErJeg2.WebApi.dll"]
