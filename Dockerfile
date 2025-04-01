FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ToDoList_Backend/ToDoList_Backend.csproj ToDoList_Backend/
RUN dotnet restore ToDoList_Backend/ToDoList_Backend.csproj

COPY . .
WORKDIR /src/ToDoList_Backend
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE 80

ENTRYPOINT ["dotnet", "ToDoList_Backend.dll"]
