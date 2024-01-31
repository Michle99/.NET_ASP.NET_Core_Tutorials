# .NET Microservice

## Install .NET SDK

1. Download .NET 8 SDK: [Dowload .NET 8](https://dotnet.microonsoft.com/en-us/download)

2. Check .NET version

```
dotnet --version
```

## Create Service

1. Create Your Microservice:

```
dotnet new webapi -o MyMicroservice --no-https
```

2. Run the service:

```             
dotnet run
```

3. Navigate to http://localhost:<port number>/weatherforecast


## Install Docker

1. Install Docker: [download and install Docker](https://docs.docker.com/desktop/install/windows-install/)

2. Check Docker version:

```
docker --version
```

3. Navigate to the app directory:

```
cd <project_name>
```

4. Create a `Dockerfile` in the project directory.

5. Add the following to the `Dockerfile`:

```
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY <project_name>.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "<project_name>.dll"]

```

6. Create a Docker image:

```
docker build -t <image_name> .
```

7. Verify docker image:

```
docker images
```

8. Run docker image:

```
docker run -it --rm -p 3000:8080 --name <project_name_container> <project_name_service>
```
NOTE: Replace `<>` with project name and desired naming.

9. View docker container:

```
docker ps
```

