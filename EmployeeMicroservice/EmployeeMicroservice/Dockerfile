FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY EmployeeMicroservice.csproj EmployeeMicroservice/
RUN dotnet restore EmployeeMicroservice/EmployeeMicroservice.csproj
WORKDIR /src/EmployeeMicroservice
COPY . .
RUN dotnet build EmployeeMicroservice.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeMicroservice.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeMicroservice.dll"]
