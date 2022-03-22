FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RuneCube/RuneCube.csproj", "RuneCube/"]
COPY ["DomainModels/DomainModels.csproj", "DomainModels/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "RuneCube/RuneCube.csproj"
COPY . .
WORKDIR "/src/RuneCube"
RUN dotnet build "RuneCube.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "RuneCube.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet RuneCube.dll
