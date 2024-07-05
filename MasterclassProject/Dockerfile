# Use an official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Copy the published output of your application to the container
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MasterclassProject/MasterclassProject.csproj", "MasterclassProject/"]
RUN dotnet restore "MasterclassProject/MasterclassProject.csproj"
COPY . .
WORKDIR "/src/MasterclassProject"
RUN dotnet build "MasterclassProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasterclassProject.csproj" -c Release -o /app/publish

# Set up the entry point for your application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterclassProject.dll"]
