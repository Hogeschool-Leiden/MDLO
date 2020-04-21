FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILDER
WORKDIR /app
COPY ./ .
RUN dotnet restore
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as RUNTIME
WORKDIR /app
COPY --from=BUILDER /app/output .
EXPOSE 80
ENTRYPOINT ["dotnet", "Demo.Api.dll"]