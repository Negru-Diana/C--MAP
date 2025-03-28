using Task = Lab10.domain.Task;

namespace Lab10.containers;

public class QueueContainer : AbstractContainer
{
    //Clasa QueueContainer extinde clasa AbstractContainer
    
    //Constructor
    public QueueContainer() : base()
    {
    }
    
    //Suprascrie metoda remove din clasa AbstractContainer (pentru FIFO)
    public override Task remove()
    {
        if (tasks.Count > 0)
        {
            //Elimina si returneaza primul element din lista (FIFO)
            Task task = tasks[0];
            tasks.RemoveAt(0);
            return task;
        }
        else
        {
            return null;
        }
    }
}