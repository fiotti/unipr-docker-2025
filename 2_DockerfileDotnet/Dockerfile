FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build "2_DockerfileDotnet.csproj" -c Release -o /app/build
RUN dotnet publish "2_DockerfileDotnet.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "2_DockerfileDotnet.dll"]
