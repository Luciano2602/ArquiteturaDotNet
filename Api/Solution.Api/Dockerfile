FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 28686
EXPOSE 44386

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Solution.Api/Solution.Api.csproj", "Solution.Api/"]
RUN dotnet restore "Solution.Api/Solution.Api.csproj"
COPY . .
WORKDIR "/src/Solution.Api"
RUN dotnet build "Solution.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Solution.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Solution.Api.dll"]