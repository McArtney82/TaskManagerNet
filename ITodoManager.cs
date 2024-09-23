namespace TaskManagerNet;

public interface ITodoManager
{
    IEnumerable<object> getTodoItems();
    TodoItem? getTodoItem(int id);
    void addTodoItem(TodoItem? item);
    TodoItem? editTodoItem(TodoItem item);
    void removeTodoItem(int id);
}