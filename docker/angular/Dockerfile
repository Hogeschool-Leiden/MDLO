FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILDER
ARG source
ARG sln
WORKDIR /app
COPY ${source} .
RUN dotnet restore
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
RUN dotnet publish ${sln} -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as RUNTIME
ARG source
ARG runnable
ENV dll=${runnable}
WORKDIR /app
COPY --from=BUILDER /app/output .
EXPOSE 80
ENTRYPOINT dotnet ${dll}
