# Etapa 1: Constru��o da aplica��o
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar os arquivos da solu��o
COPY . .

# Restaurar as depend�ncias
RUN dotnet restore "ProvaPub.sln"

# Construir a aplica��o
RUN dotnet build "ProvaPub.sln" -c Release -o /app/build

# Etapa 2: Publica��o da aplica��o
FROM build AS publish
RUN dotnet publish "ProvaPub.Api/ProvaPub.Api.csproj" -c Release -o /app/publish

# Etapa 3: Rodando a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definir o comando para rodar a aplica��o
ENTRYPOINT ["dotnet", "ProvaPub.Api.dll"]
