# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all project files (so all layers are visible)
COPY . .

# Move into the API folder where the .csproj file lives
WORKDIR /src/API

# Restore dependencies
RUN dotnet restore API.csproj

# Publish the app
RUN dotnet publish API.csproj -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Railway will inject the PORT env var automatically
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "API.dll"]
