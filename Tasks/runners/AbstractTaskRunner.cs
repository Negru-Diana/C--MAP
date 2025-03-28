using Task = Lab10.domain.Task;

namespace Lab10.runners;

public class AbstractTaskRunner : TaskRunner
{
    //Clasa  AbstractTaskRunner interfata TaskRunner
    
    //Atribute
    protected TaskRunner taskRunner;
    
    //Constructori
    public AbstractTaskRunner(TaskRunner taskRunner)
    {
        this.taskRunner = taskRunner;
        if (this.taskRunner == null)
        {
            throw new ArgumentNullException(nameof(taskRunner), "TaskRunner cannot be null");
        }
    }

    public AbstractTaskRunner()
    {
        this.taskRunner = null;
    }
    
    //Suprascrie metoda executeOneTask din interfata TaskRunner
    public virtual void executeOneTask()
    {
        taskRunner.executeOneTask();
    }
    
    //Suprascrie metoda hasTask din interfata TaskRunner
    public virtual bool hasTask()
    {
        return taskRunner.hasTask();
    }

    //Suprascrie metoda executeAll din interfata TaskRunner
    public virtual void executeAll()
    {
        while (hasTask())
        {
            executeOneTask();
        }
    }
    
    //Suprascrie metoda addTask din interfata TaskRunner
    public virtual void addTask(Task task)
    {
        if (taskRunner == null)
        {
            throw new InvalidOperationException("TaskRunner is not initialized.");
        }
        taskRunner.addTask(task);
    }
}