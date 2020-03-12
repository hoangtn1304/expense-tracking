FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100 AS build-env
WORKDIR /app

ENV PATH="$PATH:$HOME/.dotnet/tools/"

# Copy csproj 
COPY *.csproj ./
RUN dotnet restore

# Copy everything build
COPY . ./
RUN dotnet publish -c Release -o .

# Heroku doesnt like ENTRYPOINT
# ENTRYPOINT ["dotnet", "expense-tracking-api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet expense-tracking-api.dll