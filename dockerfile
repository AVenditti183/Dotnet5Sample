FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src
COPY . .
RUN dotnet publish "Server/dotnet5sample.Server.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet5sample.Server.dll"]