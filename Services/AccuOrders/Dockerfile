FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY Services/AccuOrders/AccuOrders.csproj Services/AccuOrders/
COPY Core/SampleWapper/SampleWapper.csproj Core/SampleWapper/
RUN dotnet restore Services/AccuOrders/AccuOrders.csproj
COPY . .
WORKDIR /src/Services/AccuOrders
RUN dotnet build AccuOrders.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AccuOrders.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AccuOrders.dll"]
