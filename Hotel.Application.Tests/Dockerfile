FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Hotel.Application.Tests/Hotel.Application.Tests.csproj", "Hotel.Application.Tests/"]
COPY ["Hotel.Persistance/Hotel.Persistance.csproj", "Hotel.Persistance/"]
COPY ["Hotel.Application/Hotel.Application.csproj", "Hotel.Application/"]
COPY ["Hotel.Common/Hotel.Common.csproj", "Hotel.Common/"]
COPY ["Hotel.Domain/Hotel.Domain.csproj", "Hotel.Domain/"]
RUN dotnet restore "Hotel.Application.Tests/Hotel.Application.Tests.csproj"

COPY . .
WORKDIR "/src/Hotel.Application.Tests"
RUN dotnet build "Hotel.Application.Tests.csproj" --no-restore -c Release -o /app
ENTRYPOINT ["dotnet", "test"]   
