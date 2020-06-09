FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as RUNTIME
ARG source
ARG runnable
ENV dll=${runnable}
WORKDIR /app
COPY ${source:-./obj/Docker/publish} .
EXPOSE 80
ENTRYPOINT dotnet ${dll}
