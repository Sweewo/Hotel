FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Hotel.Web.Api/Hotel.Web.Api.csproj", "Hotel.Web.Api/"]
COPY ["Hotel.Infrastructure/Hotel.Infrastructure.csproj", "Hotel.Infrastructure/"]
COPY ["Hotel.Common/Hotel.Common.csproj", "Hotel.Common/"]
COPY ["Hotel.Application/Hotel.Application.csproj", "Hotel.Application/"]
COPY ["Hotel.Domain/Hotel.Domain.csproj", "Hotel.Domain/"]
COPY ["Hotel.Persistance/Hotel.Persistance.csproj", "Hotel.Persistance/"]
RUN dotnet restore "Hotel.Web.Api/Hotel.Web.Api.csproj"
COPY . .
WORKDIR "/src/Hotel.Web.Api"
RUN dotnet build "Hotel.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotel.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hotel.Web.Api.dll"]