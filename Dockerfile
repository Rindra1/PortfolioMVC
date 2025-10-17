# 1️⃣ Image de base pour exécuter l'application ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
# (Optionnel : Render expose souvent le port 10000 automatiquement)

# 2️⃣ Image pour construire le projet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier le fichier .csproj et restaurer les dépendances
COPY ["PortfolioMVC.csproj", "./"]
RUN dotnet restore "./PortfolioMVC.csproj"

# Copier le reste du projet et publier
COPY . .
RUN dotnet publish "PortfolioMVC.csproj" -c Release -o /app/publish

# 3️⃣ Image finale pour exécuter l'application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Démarre ton application MVC
ENTRYPOINT ["dotnet", "PortfolioMVC.dll"]
