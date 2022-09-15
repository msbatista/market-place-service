FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN dotnet tool update --global dotnet-ef --version 6.0.9
WORKDIR /src
COPY . .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN dotnet restore "src/WebApi/WebApi.csproj"
RUN dotnet build "src/WebApi/WebApi.csproj" --no-restore