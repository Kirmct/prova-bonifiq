# Etapa 1: Construção da aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar os arquivos da solução
COPY . .

# Restaurar as dependências
RUN dotnet restore "ProvaPub.sln"

# Construir a aplicação
RUN dotnet build "ProvaPub.sln" -c Release -o /app/build

# Etapa 2: Publicação da aplicação
FROM build AS publish
RUN dotnet publish "ProvaPub.Api/ProvaPub.Api.csproj" -c Release -o /app/publish

# Etapa 3: Rodando a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definir o comando para rodar a aplicação
ENTRYPOINT ["dotnet", "ProvaPub.Api.dll"]
