#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MVC Site/MVC Site.csproj", "MVC Site/"]
RUN dotnet restore "MVC Site/MVC Site.csproj"
COPY . .
WORKDIR "/src/MVC Site"
RUN dotnet build "MVC Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVC Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVC Site.dll"]