##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["ProductsService/ProductsService.csproj", "ProductsService/"]
#RUN dotnet restore "ProductsService/ProductsService.csproj"
#COPY . .
#WORKDIR "/src/ProductsService"
#RUN dotnet build "ProductsService.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ProductsService.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProductsService.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore

run dotnet publish -c release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /src
COPY --from=build /src/publish .
ENTRYPOINT ["dotnet","ProductsService.dll"]
