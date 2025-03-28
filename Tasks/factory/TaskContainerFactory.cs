using Lab10.containers;

namespace Lab10.factory;

public class TaskContainerFactory : Factory
{
    //Implementeaza interfata Factory folosind principiul Singleton
    
    private static TaskContainerFactory instance;
    
    //Constructor
    private TaskContainerFactory() { }
    
    //Metoda pentru a obtine instanta clasei
    public static TaskContainerFactory getInstance()
    {
        if (instance == null)
        {
            instance = new TaskContainerFactory();
        }
        return instance;
    }

    //Implementeaza metoda createContainer din interfata Factory
    public Container createContainer(ContainerStrategy strategy)
    {
        if (strategy.Equals(ContainerStrategy.FIFO))
        {
            return new QueueContainer();
        }
        else
        {
            return new StackContainer();
        }
    }
}