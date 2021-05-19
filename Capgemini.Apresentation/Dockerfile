#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Capgemini.Apresentation/Capgemini.Apresentation.csproj", "Capgemini.Apresentation/"]
RUN dotnet restore "Capgemini.Apresentation/Capgemini.Apresentation.csproj"
COPY . .
WORKDIR "/src/Capgemini.Apresentation"
RUN dotnet build "Capgemini.Apresentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Capgemini.Apresentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Capgemini.Apresentation.dll"]