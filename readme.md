
First build the application
```
dotnet build .\client\client.csproj
dotnet build .\apigateway\ApiGateway.csproj
dotnet build .\service1\Service1.csproj
```

Then start the containers:

```
docker compose up
```