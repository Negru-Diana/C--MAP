using Lab10.containers;
using Lab10.factory;
using Task = Lab10.domain.Task;

namespace Lab10.runners;

public class StrategyTaskRunner : AbstractTaskRunner
{
    //Clasa StrategyTaskRunner extinde clasa AbstractTaskRunner
    //Folosit pentru a alege strategia pentru gestionarea containerelor
    
    private Container container;
    
    //Constructor
    public StrategyTaskRunner(ContainerStrategy strategy)
    {
        container = TaskContainerFactory.getInstance().createContainer(strategy);
        if (container == null)
        {
            throw new InvalidOperationException("Failed to create a container.");
        }
    }
    
    //Suprascrie metoda executeOneTask din interfata TaskRunner
    public override void executeOneTask()
    {
        if (hasTask())
        {
            Task task = container.remove();
            if (task != null)
            {
                task.execute();
            }
        }
    }
    
    //Suprascrie metoda hasTask din interfata TaskRunner
    public override bool hasTask()
    {
        return !container.isEmpty();
    }
    
    //Suprascrie metoda executeAll din interfata TaskRunner
    public override void executeAll()
    {
        while (hasTask())
        {
            executeOneTask();
        }
    }
    
    //Suprascrie metoda addTask din interfata TaskRunner
    public override void addTask(Task task)
    {
        container.add(task);
    }
}