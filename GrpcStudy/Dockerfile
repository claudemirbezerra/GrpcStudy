#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GrpcStudy/GrpcStudy.csproj", "GrpcStudy/"]
RUN dotnet restore "GrpcStudy/GrpcStudy.csproj"
COPY . .
WORKDIR "/src/GrpcStudy"
RUN dotnet build "GrpcStudy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcStudy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcStudy.dll"]