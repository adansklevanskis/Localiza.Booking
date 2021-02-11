#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/booking/Booking.API/Booking.API.csproj", "src/services/booking/Booking.API/"]
RUN dotnet restore "src/services/booking/Booking.API/Booking.API.csproj"
COPY . .
WORKDIR "/src/src/services/booking/Booking.API"
RUN dotnet build "Booking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.API.dll"]