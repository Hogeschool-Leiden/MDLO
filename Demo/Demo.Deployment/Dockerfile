FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILDER
WORKDIR /app
EXPOSE 80
COPY ./ .
RUN dotnet publish -c Release -o output


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/output .
ENTRYPOINT ["dotnet", "Demo.Api.dll"]
