#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.BackgroundTasks/Ordering.BackgroundTasks.csproj", "src/Services/Ordering/Ordering.BackgroundTasks/"]
RUN dotnet restore "src/Services/Ordering/Ordering.BackgroundTasks/Ordering.BackgroundTasks.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Ordering.BackgroundTasks"
RUN dotnet build "Ordering.BackgroundTasks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.BackgroundTasks.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.BackgroundTasks.dll"]