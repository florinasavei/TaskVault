# Use the appropriate base image for .NET 7.0 on Linux
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the appropriate base image for .NET 7.0 on Linux for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TaskVault.SummaryAPI/TaskVault.SummaryAPI.csproj", "src/TaskVault.SummaryAPI/"]
RUN dotnet restore "src/TaskVault.SummaryAPI/TaskVault.SummaryAPI.csproj"
COPY . .
WORKDIR "/src/src/TaskVault.SummaryAPI"
RUN dotnet build "TaskVault.SummaryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskVault.SummaryAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Set the final stage and copy the published application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point to run your application
ENTRYPOINT ["dotnet", "TaskVault.SummaryAPI.dll"]
