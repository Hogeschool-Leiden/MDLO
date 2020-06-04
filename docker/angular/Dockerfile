FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as RUNTIME
ARG source
ARG runnable
ENV dll=${runnable}
WORKDIR /app
COPY --from=BUILDER /app/output .
EXPOSE 80
ENTRYPOINT dotnet ${dll}
