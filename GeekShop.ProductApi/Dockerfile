FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeekShop.ProductApi/GeekShop.ProductApi.csproj", "GeekShop.ProductApi/"]
RUN dotnet restore "GeekShop.ProductApi/GeekShop.ProductApi.csproj"
COPY . .
WORKDIR "/src/GeekShop.ProductApi"
RUN dotnet build "GeekShop.ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShop.ProductApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShop.ProductApi.dll"]
