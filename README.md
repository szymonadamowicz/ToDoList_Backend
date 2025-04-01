
# ToDo List API – Backend

This is the backend part of the ToDo List application – a simple task management system with features such as task creation, editing, deletion, completion, reordering (sorting), and automatic hiding of completed tasks after 24 hours.

## Technologies Used

- **C#** with **.NET 8.0**
- **ASP.NET Core Web API**
- **Dependency Injection**
- **Model-View-ViewModel (MVVM) inspired structure**
- **RESTful API design**
- **JSON file as in-memory data store** (no database used)
- **CORS** enabled for frontend communication

## Project Structure
```
- `Controllers/TaskController.cs`: main entry point for all HTTP endpoints
- `Models/TaskModel.cs`: representation of the data layer model
- `ViewModels/TaskViewModel.cs`: exposed model for frontend interaction
- `Services/TaskService.cs`: contains business logic for task manipulation, sorting, and timed hiding
- `Program.cs`: app configuration, services registration, and middleware setup
```
## Main Features

- Create, update, delete tasks
- Mark tasks as completed
- Reorder tasks via drag-and-drop (integrated with frontend)
- Automatically hide completed tasks after 24 hours (simulated logic)
- Clear distinction between internal model and public-facing data via ViewModels

## API Endpoints
```
| Method | Endpoint                         | Description                      |
|--------|----------------------------------|----------------------------------|
| GET    | `/api/tasks`                     | Get all tasks                    |
| POST   | `/api/tasks`                     | Create new task                  |
| POST   | `/api/tasks/{id}`                | Update existing task             |
| DELETE | `/api/tasks/{id}`                | Remove task                      |
| POST   | `/api/tasks/swap`                | Reorder tasks by dragging        |
| POST   | `/api/tasks/hide/{id}`           | Manually hide a completed task   |
| GET    | `/api/theme`                     | Get all theme                    |
| POST   | `/api/theme/changeTheme          | Manually change theme (color)    |
| POST   | `/api/tasks/theme/changeLanguage | Manually change theme language   |

```
## 🧪 How to Run

1. Navigate to the backend directory:
    ```
    cd ToDoList_Backend
    ```

2. Run the backend:
    ```
    dotnet run
    ```

3. API will be available at:
    ```
    https://localhost:5001/api/tasks
    ```

Make sure to enable CORS and run the frontend in parallel to test full integration.

