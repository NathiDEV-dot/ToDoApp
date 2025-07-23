// Services/TodoService.cs
using ToDoApp.Models;

namespace TodoApp.Services;

public class TodoService
{
    private readonly List<ToDo> _todos = new();
    private int _nextId = 1; // Auto-incrementing ID

    // Get all todos (sorted by completion status)
    public List<ToDo> GetAll() => _todos
        .OrderBy(t => t.IsCompleted)
        .ThenBy(t => t.DueDate)
        .ToList();

    // Add a new todo
    public void Add(ToDo todo)
    {
        todo.Id = _nextId++;
        _todos.Add(todo);
    }

    // Toggle completion status
    public void ToggleComplete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null) 
        {
            todo.IsCompleted = !todo.IsCompleted;
        }
    }

    // Optional: Delete a todo
    public void Delete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
    }
}