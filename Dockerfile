FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN curl --silent --location https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ./UrlShortener.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish ./UrlShortener.csproj -c Release -o /app/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "UrlShortener.dll"]
