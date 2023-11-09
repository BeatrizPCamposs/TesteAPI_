FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY . ./

RUN dotnet publish -c Release -o out ./ZooAPI.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /out .

ENTRYPOINT ["dotnet", "ZooAPI".dll"]