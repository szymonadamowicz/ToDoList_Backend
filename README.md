# ToDo List App – Backend

This is the backend for the ToDo List application – a task management system that includes task creation, editing, deletion, completion, reordering, and automatic hiding of completed tasks after 24 hours.

## Features

- Task creation, update, and deletion
- Mark tasks as completed
- Reorder tasks via drag-and-drop (integrated with frontend)
- Automatically hide completed tasks after 24 hours
- Clear separation of internal and external data models using ViewModels

## Tech Stack

- C# with .NET 8.0
- ASP.NET Core Web API
- Dependency Injection
- MVVM-inspired structure
- RESTful API design
- JSON file as in-memory data store (no external database)
- CORS enabled for frontend communication

## Project Structure

```
Controllers/TaskController.cs     // Handles HTTP endpoints
Models/TaskModel.cs              // Internal data model
ViewModels/TaskViewModel.cs      // Data model exposed to frontend
Services/TaskService.cs          // Business logic for task management
Program.cs                       // App configuration and service setup
```

## API Endpoints

| Method | Endpoint                          | Description                    |
|--------|-----------------------------------|--------------------------------|
| GET    | `/api/tasks`                      | Get all tasks                  |
| POST   | `/api/tasks`                      | Create new task                |
| POST   | `/api/tasks/{id}`                 | Update existing task           |
| DELETE | `/api/tasks/{id}`                 | Delete task                    |
| POST   | `/api/tasks/swap`                 | Reorder tasks via drag-and-drop|
| POST   | `/api/tasks/hide/{id}`            | Manually hide completed task   |
| GET    | `/api/theme`                      | Get current theme              |
| POST   | `/api/theme/changeTheme`          | Change theme color             |
| POST   | `/api/tasks/theme/changeLanguage` | Change language                |

## How to Run

1. Navigate to the backend directory:
   ```
   cd ToDoList_Backend
   ```

2. Run the application:
   ```
   dotnet run
   ```

3. Access the API at:
   ```
   https://localhost:5001/api/tasks
   ```

Make sure the frontend is running in parallel and CORS is enabled for full integration.
