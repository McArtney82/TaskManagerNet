namespace TaskManagerNet;

public class TodoManager : ITodoManager
{
    private readonly List<TodoItem?> TodoItemList = [];
    private int TodoIndex = 0;
    
    public IEnumerable<object> getTodoItems()
    {
        return TodoItemList.Select(item => new { item.Id, item.Title }).ToList();
    }

    public TodoItem? getTodoItem(int id)
    {
        return TodoItemList.Find(item => item.Id == id);
    }

    public void addTodoItem(TodoItem? item)
    {
        item.Id = TodoIndex;
        TodoItemList.Add(item);
        incrementIndex();
    }

    public TodoItem? editTodoItem(TodoItem item)
    {
        var existingItem = TodoItemList.Find(i => i?.Id == item.Id);

        if (existingItem != null)
        {
            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.Priority = item.Priority;
        }

        return existingItem;
    }

    public void removeTodoItem(int id)
    {
        TodoItemList.Remove(getTodoItem(id));
    }

    private void incrementIndex()
    {
        TodoIndex++;
    }
}