FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . .

RUN dotnet build -c Release

ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]