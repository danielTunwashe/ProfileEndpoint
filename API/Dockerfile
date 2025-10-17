# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY ../Application ./Application
COPY ../Domain ./Domain
COPY ../Infrastructure ./Infrastructure
COPY . ./API

WORKDIR /src/API
RUN dotnet restore API.csproj
RUN dotnet publish -c Release -o /app/publish

# Use a smaller runtime image for hosting
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "API.dll"]
