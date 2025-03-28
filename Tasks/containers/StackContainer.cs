using Task = Lab10.domain.Task;

namespace Lab10.containers;

public class StackContainer : AbstractContainer
{
    //Clasa StackContainer extinde clasa AbstractContainer
        
    //Constructor
    public StackContainer() : base()
    {
    }
    
    //Suprascrie metoda remove din clasa AbstractContainer (pentru LIFO)
    public override Task remove()
    {
        if (tasks.Count > 0)
        {
            //Elimina si returneaza ultimul element din lista (LIFO)
            Task task = tasks[tasks.Count - 1];
            tasks.RemoveAt(tasks.Count - 1);
            return task;
        }
        else
        {
            return null;
        }
    }
}