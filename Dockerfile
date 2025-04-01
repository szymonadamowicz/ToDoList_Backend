FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . . 
RUN dotnet restore "./ToDoList_Backend.csproj"
RUN dotnet publish "./ToDoList_Backend.csproj" -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out . 

ENV ASPNETCORE_URLS=http://+:$PORT

EXPOSE 10000
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ToDoList_Backend/ToDoList_Backend.csproj ToDoList_Backend/
RUN dotnet restore ToDoList_Backend/ToDoList_Backend.csproj

COPY . .
WORKDIR /src/ToDoList_Backend
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ToDoList_Backend.dll"]

CMD ["dotnet", "ToDoList_Backend.dll"]
