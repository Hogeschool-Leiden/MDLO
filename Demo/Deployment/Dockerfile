# To build this Dockerfile you need to run this `docker build -t <name> -f ./Deployment/Dockerfile .` 
# from the root directory (Demo/) 

# Create build environment
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy csproj from api and restore as distinct layers
COPY ./Demo.Api/Demo.Api.csproj ./src/
RUN dotnet restore ./src/Demo.Api.csproj

# Copy csproj from test and restore as distinct layers
COPY ./Demo.Api.Test/Demo.Api.Test.csproj ./test/
RUN dotnet restore ./test/Demo.Api.Test.csproj

# Copy everything else
COPY ./Demo.Api/ ./src
COPY ./Demo.Api.Test/ ./test

# Test
RUN dotnet test -c Release --collect:"Code Coverage" ./test/Demo.Api.Test.csproj

# Publish
RUN dotnet publish -c Release -o out ./src/Demo.Api.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Demo.Api.dll"]