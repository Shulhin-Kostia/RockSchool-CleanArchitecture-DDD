FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Modules/Lessons/Lessons.Application/Lessons.Application.csproj", "Modules/Lessons/Application/"]
COPY ["Modules/Lessons/Lessons.Domain/Lessons.Domain.csproj", "Modules/Lessons/Domain/"]
COPY ["Modules/Lessons/Lessons.Infrastructure/Lessons.Infrastructure.csproj", "Modules/Lessons/Infrastructure/"]
COPY ["BuildingBlocks/BuildingBlocks.Infrastructure/BuildingBlocks.Infrastructure.csproj", "BuildingBlocks/Infrastructure/"]
COPY ["BuildingBlocks/BuildingBlocks.Domain/BuildingBlocks.Domain.csproj", "BuildingBlocks/Domain/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ADD API/entrypoint.sh /

ENTRYPOINT ["/bin/bash", "/entrypoint.sh"]