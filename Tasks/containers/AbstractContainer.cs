using Task = Lab10.domain.Task;

namespace Lab10.containers;

public abstract class AbstractContainer : Container
{
    //Clasa AbstractContainer implementeaza interfata Container
    
    protected List<Task> tasks; //Lista de task-uri care reprezinta containerul
    
    //Constructor - initializeaza lista de task-uri cu o lista vida
    public AbstractContainer()
    {
        tasks = new List<Task>();
    }
    
    //Adaugare Task
    public void add(Task task)
    {
        tasks.Add(task);
    }
    
    //Returneaza dimensiunea containerului
    public int size()
    {
        return tasks.Count;
    }
    
    //Verific daca containerul este gol
    public bool isEmpty()
    {
        return tasks.Count == 0;
    }
    
    //Metoda abstracta pentru eliminarea unui task, implementata in clasele derivate
    public abstract Task remove();
}