FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dots-server-v2/dots-server-v2.csproj", "dots-server-v2/"]
RUN dotnet restore "dots-server-v2/dots-server-v2.csproj"
COPY . .
WORKDIR "/src/dots-server-v2"
RUN dotnet build "dots-server-v2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dots-server-v2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dots-server-v2.dll"]
