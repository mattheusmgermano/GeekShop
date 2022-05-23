FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeekShop.Web/GeekShop.Web.csproj", "GeekShop.Web/"]
RUN dotnet restore "GeekShop.Web/GeekShop.Web.csproj"
COPY . .
WORKDIR "/src/GeekShop.Web"
RUN dotnet build "GeekShop.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShop.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShop.Web.dll"]
