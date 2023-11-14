FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY ["ZooAPI - Lionnez/ZooAPI/ZooAPI.csproj", "./"]

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out "ZooAPI - Lionnez/ZooAPI/ZooAPI.csproj"

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "ZooAPI.dll"]
