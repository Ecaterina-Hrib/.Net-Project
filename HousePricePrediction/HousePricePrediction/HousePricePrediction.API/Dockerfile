FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE $PORT
# ENV ASPNETCORE_URLS=http://*:5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HousePricePrediction.API.csproj", "./"]
RUN dotnet restore "./HousePricePrediction.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "HousePricePrediction.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HousePricePrediction.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","HousePricePrediction.API.dll"]