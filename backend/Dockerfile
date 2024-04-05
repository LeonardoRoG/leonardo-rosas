FROM mcr.microsoft.com/dotnet/sdk:8.0.101-jammy-amd64 as build

COPY . /source

WORKDIR /source/Novit.Academia

RUN dotnet restore \
    && dotnet publish --configuration Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0.1-jammy-amd64 as runtime

EXPOSE 5000

COPY --from=build /publish/ /app


WORKDIR /app

ENTRYPOINT [ "dotnet", "Novit.Academia.dll"]