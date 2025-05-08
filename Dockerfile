FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

COPY myApp/publish .

ENTRYPOINT ["dotnet", "myApp.dll"]
