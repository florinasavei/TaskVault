# Use the appropriate base image for .NET 7.0 on Linux
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the appropriate base image for .NET 7.0 on Linux for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TaskVault.API/TaskVault.API.csproj", "src/TaskVault.API/"]
RUN dotnet restore "src/TaskVault.API/TaskVault.API.csproj"
COPY . .
WORKDIR "/src/src/TaskVault.API"
RUN dotnet build "TaskVault.API.csproj" -c Release -o /app/build

## Use the image for SQL Server for Linux from Docker Hub
## Configure the connection string for your application
#FROM mcr.microsoft.com/mssql/server:2019-latest AS sqlserver
#ENV SA_PASSWORD=YourPassword
#ENV ACCEPT_EULA=Y
#ENV MSSQL_PID=Developer
#
#
## Set the database name and create a user and database
#ENV DB_NAME=master
#ENV DB_USER=sa
#RUN /opt/mssql/bin/sqlservr & sleep 10 \
    #&& /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P YourPassword -Q "CREATE DATABASE $DB_NAME" \
    #&& /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P YourPassword -d $DB_NAME -Q "CREATE LOGIN $DB_USER WITH PASSWORD = 'S3cur3P@ssW0rd!', DEFAULT_DATABASE = $DB_NAME; ALTER SERVER ROLE sysadmin ADD MEMBER $DB_USER" \
    #&& pkill sqlservr
#
#
# Continue with your build
FROM build AS publish
RUN dotnet publish "TaskVault.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Set the final stage and copy the published application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the database port (change the port if needed)
EXPOSE 1433

# Set the entry point to run your application
ENTRYPOINT ["dotnet", "TaskVault.API.dll"]
