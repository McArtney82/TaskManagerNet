// See https://aka.ms/new-console-template for more information

using TaskManagerNet;

TodoManager TodoItemManager = new TodoManager();
bool quit = false;
int id = 0;
string inputTitle = "";
string inputDescription = "";
short inputPriority = 0;
bool validPriority = true;
TodoItem? TodoItem = null;
string? input = "";

while (!quit)
{
    Console.WriteLine("Here is a list of current to do item");
    if (TodoItemManager.getTodoItems().Any())
    {
        foreach (var item in TodoItemManager.getTodoItems())
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("No items found");
    }
    
    Console.WriteLine("(a)dd To Do");
    Console.WriteLine("(r)emove To Do");
    Console.WriteLine("(s)how To Do");
    Console.WriteLine("(e)dit To Do");
    Console.WriteLine("(q)uit");
    input = Console.ReadLine();
    switch (input)
    {
       case "q":
           quit = true;
           break;
       case "a":
           Console.WriteLine("Enter the name of the item");
           inputTitle = Console.ReadLine();
           Console.WriteLine("Enter the description of the item");
           inputDescription = Console.ReadLine();
           Console.WriteLine("Enter the priority of the item 1 - 5");
           inputPriority = Convert.ToInt16(Console.ReadLine());
           validPriority = inputPriority >= 1 && inputPriority <= 5;
           if (validPriority && inputTitle.Length > 0 && inputDescription.Length > 0)
           {
               TodoItem = new TodoItem();
               TodoItem.Title = inputTitle;
               TodoItem.Description = inputDescription;
               TodoItem.Priority = inputPriority;
               TodoItemManager.addTodoItem(TodoItem);
           }
           else
           {
               Console.WriteLine("Invalid input");
               if (!validPriority)
               {
                   Console.WriteLine("Invalid priority:");
                   Console.WriteLine(inputPriority);
                   Console.WriteLine("Priority must be 1 - 5");
               }
           }

           break;
       case "r":
           Console.WriteLine("Enter the id of the item to remove");
           id = Convert.ToInt32(Console.ReadLine());
           TodoItemManager.removeTodoItem(id);
           break;
       case "s":
           Console.WriteLine("Enter the id of the item to show");
           id = Convert.ToInt32(Console.ReadLine());
           TodoItem = TodoItemManager.getTodoItem(id);
           if (TodoItem != null)
           {
               Console.WriteLine("Here is the item with id " + id);
               Console.WriteLine(TodoItem);
           }
           else
           {
               Console.WriteLine("No To Do Item with id " + id);
           }
           break;
       case "e":
           Console.WriteLine("Enter the id of the item to edit");
           id = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Enter the name of the item or hit enter to not edit");
           inputTitle = Console.ReadLine();
           Console.WriteLine("Enter the description of the item or hit enter to not edit");
           inputDescription = Console.ReadLine();
           Console.WriteLine("Enter the priority of the item 1 - 5 or hit enter to not edit");
           string priorityInput = Console.ReadLine();
           TodoItem = TodoItemManager.getTodoItem(id);
               
           if (TodoItem != null)
           {
               TodoItem.Title = !string.IsNullOrEmpty(inputTitle) ? inputTitle : TodoItem.Title;
               TodoItem.Description = !string.IsNullOrEmpty(inputDescription) ? inputDescription : TodoItem.Description;
               if (!string.IsNullOrEmpty(priorityInput))
               {
                   if (short.TryParse(priorityInput, out inputPriority) && inputPriority >= 1 && inputPriority <= 5)
                   {
                       TodoItem.Priority = inputPriority;
                   }
                   else
                   {
                       Console.WriteLine("Invalid priority: Priority must be between 1 and 5.");
                   }
               }

               TodoItemManager.editTodoItem(TodoItem);
           }
           
           break;
       default :
           Console.WriteLine("Invalid input");
           break;
           
    }
    Console.WriteLine(input);
}


