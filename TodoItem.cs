//create interface called ITodoManager with signatures for methods
//method to return list of id's and titles
//method get details of single todo item return all attributes
//method add a to do item
//method edit to do item by id
//method to remove to do item (return void)
//create a class that implements the interface
//private read only list 
//methods to perform actions on that last (add to the list, edit in the list etc)
//self incrementing id logic 
//consume the class by Program.cs prompts to add item, edit item etc
//here is a list of all to do
//here is the details for that 
//edit it
//delete it
namespace TaskManagerNet;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public short Priority { get; set; }
    
    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Description: {Description}, Priority: {Priority}";
    }
} 