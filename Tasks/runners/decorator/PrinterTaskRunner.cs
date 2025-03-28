namespace Lab10.runners;

public class PrinterTaskRunner : AbstractTaskRunner
{
    //Clasa PrinterTaskRunner extinde clasa AbstractTaskRunner (decorator)
    
    //Formatter static pentru data
    private static readonly string DATE_FORMAT = "yyyy-MM-dd HH:mm";
    
    //Constructor
    public PrinterTaskRunner(TaskRunner taskRunner) : base(taskRunner)
    {
        if (taskRunner == null)
        {
            throw new ArgumentNullException(nameof(taskRunner), "TaskRunner cannot be null");
        }
    }

    public override void executeOneTask()
    {
        base.executeOneTask();
        Console.WriteLine("Task executed at: " + DateTime.Now.ToString(DATE_FORMAT));
    }
}