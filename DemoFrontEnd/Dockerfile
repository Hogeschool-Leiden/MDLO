FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILDER
WORKDIR /app
COPY DemoFrontend.Api .
RUN dotnet restore
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
RUN dotnet publish -c Release -o output


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as RUNTIME
WORKDIR /app
COPY --from=BUILDER /app/output .
EXPOSE 80
ENTRYPOINT ["dotnet", "DemoFrontend.Api.dll"]