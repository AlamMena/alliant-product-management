# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the .csproj files for each layer
COPY AlliantProductManagementServer.Domain/*.csproj ./AlliantProductManagementServer.Domain/
COPY AlliantProductManagementServer.Persistence/*.csproj ./AlliantProductManagementServer.Persistence/
COPY AlliantProductManagementServer.Application/*.csproj ./AlliantProductManagementServer.Application/
COPY AlliantProductManagementServer.WebAPI/*.csproj ./AlliantProductManagementServer.WebAPI/
COPY AlliantProductManagementServer.Tests/*.csproj ./AlliantProductManagementServer.Tests/
COPY AlliantProductManagementServer.sln ./

# Restore dependencies
RUN dotnet restore

# Copy the entire source code
COPY . .

# Build the solution
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the build output
COPY --from=build /out .

# Expose the application port
EXPOSE 8080
EXPOSE 443

# Set the entry point
ENTRYPOINT ["dotnet", "AlliantProductManagementServer.WebAPI.dll"]
