FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY . .
RUN dotnet publish LeagueCalc --sc -c Release -o /out

# FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine
FROM debian:stable-slim
WORKDIR /app
COPY --from=build /src/input/ .
COPY --from=build /out/ .
ENTRYPOINT ["./LeagueCalc", "input.txt"]
