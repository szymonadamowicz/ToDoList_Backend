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
CMD ["dotnet", "ToDoList_Backend.dll"]
