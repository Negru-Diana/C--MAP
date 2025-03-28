namespace Lab10.runners;

public class DelayTaskRunner : AbstractTaskRunner
{
    //Clasa DelayTaskRunner extinde clasa AbstractTaskRunner (decorator)
    public DelayTaskRunner(TaskRunner taskRunner) : base(taskRunner)
    {
    }

    public override void executeOneTask()
    {
        try
        {
            Thread.Sleep(3000);
        }
        catch (ThreadAbortException)
        {
        }
        
        base.executeOneTask();
    }

    public override void executeAll()
    {
        while (hasTask())
        {
            executeOneTask();
        }
    }
}