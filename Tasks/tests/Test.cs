using Lab10.containers;
using Lab10.domain;
using Lab10.factory;
using Lab10.runners;
using Lab10.sorting;
using Task = Lab10.domain.Task;

namespace Lab10.tests;

public class Test
{
    private static MessageTask[] createMessages()
    {
        MessageTask msg1 = new MessageTask("1", "feedback lab 2", "Te-ai descurcat bine 1", "teacher", "student", DateTime.Now);
        MessageTask msg2 = new MessageTask("2", "feedback lab 3", "Te-ai descurcat bine 2", "teacher", "student", DateTime.Now);
        MessageTask msg3 = new MessageTask("3", "feedback lab 4", "Te-ai descurcat bine 3", "teacher", "student", DateTime.Now);
        MessageTask msg4 = new MessageTask("4", "feedback lab 5", "Te-ai descurcat bine 4", "teacher", "student", DateTime.Now);
        MessageTask msg5 = new MessageTask("5", "feedback lab 6", "Te-ai descurcat bine 5", "teacher", "student", DateTime.Now);

        return new MessageTask[] { msg1, msg2, msg3, msg4, msg5 };
    }

    private void testMessageTask()
    {
        Console.WriteLine("Test MessageTask:");
        MessageTask[] messageTasks = createMessages();

        foreach (MessageTask messageTask in messageTasks)
        {
            Console.WriteLine(messageTask);
        }
    }
    
    private static void testSort()
    {
        int[] numbers = { 5, 3, 8, 4, 2 };

        // BubbleSort
        Console.WriteLine("\nTest BubbleSort (1):");
        Task bubbleSortTask = new SortingTask("1", "Bubble Sort", (int[])numbers.Clone(), SortStrategy.BUBBLE_SORT);
        bubbleSortTask.execute();

        // QuickSort
        Console.WriteLine("\nTest QuickSort (1):");
        Task quickSortTask1 = new SortingTask("2", "Quick Sort", (int[])numbers.Clone(), SortStrategy.QUICK_SORT);
        quickSortTask1.execute();

        int[] numbers2 = { 5, 4, 3, 2, 1 };

        // BubbleSort
        Console.WriteLine("\nTest BubbleSort (2):");
        Task bubbleSortTask2 = new SortingTask("3", "Bubble Sort", numbers2, SortStrategy.BUBBLE_SORT);
        bubbleSortTask2.execute();

        // QuickSort
        Console.WriteLine("\nTest QuickSort (2):");
        Task quickSortTask2 = new SortingTask("4", "Quick Sort", numbers2, SortStrategy.QUICK_SORT);
        quickSortTask2.execute();
    }

    private void testContainerFIFO()
    {
        Console.WriteLine("\nTest Container FIFO:");
        TaskContainerFactory factory = TaskContainerFactory.getInstance();

        Container container = factory.createContainer(ContainerStrategy.FIFO);
        
        //Adaug cateva task-uri
        Task task1 = new MessageTask("1", "Test Task 1", "Message 1", "teacher", "student", DateTime.Now);
        Task task2 = new MessageTask("2", "Test Task 2", "Message 2", "teacher", "student", DateTime.Now);
        Task task3 = new MessageTask("3", "Test Task 3", "Message 3", "teacher", "student", DateTime.Now);
        
        container.add(task1);
        container.add(task2);
        container.add(task3);
        
        // Verific daca dimensiunea containerului este 3
        if (container.size() != 3)
        {
            throw new Exception("Test container size is not 3!");
        }
        
        //Elimin si verific daca eliminarea task-urilor s-a facut corect
        Task removedTask = container.remove();
        if (!removedTask.Equals(task1))
        {
            throw new Exception("Test container removed task is not 1!");
        }
        
        removedTask = container.remove();
        if (!removedTask.Equals(task2))
        {
            throw new Exception("Test container removed task is not 2!");
        }
        
        removedTask = container.remove();
        if (!removedTask.Equals(task3))
        {
            throw new Exception("Test container removed task is not 3!");
        }
        
        //Verific daca containerul este gol
        if (container.isEmpty() == false)
        {
            throw new Exception("Test container is not empty!");
        }
        else
        {
            Console.WriteLine("success");
        }
    }
    
    private void testContainerLIFO()
    {
        Console.WriteLine("\nTest Container LIFO:");
        TaskContainerFactory factory = TaskContainerFactory.getInstance();

        Container container = factory.createContainer(ContainerStrategy.LIFO);
        
        //Adaug cateva task-uri
        Task task1 = new MessageTask("1", "Test Task 1", "Message 1", "teacher", "student", DateTime.Now);
        Task task2 = new MessageTask("2", "Test Task 2", "Message 2", "teacher", "student", DateTime.Now);
        Task task3 = new MessageTask("3", "Test Task 3", "Message 3", "teacher", "student", DateTime.Now);

        
        container.add(task1);
        container.add(task2);
        container.add(task3);
        
        // Verific daca dimensiunea containerului este 3
        if (container.size() != 3)
        {
            throw new Exception("Test container size is not 3!");
        }
        
        //Elimin si verific daca eliminarea task-urilor s-a facut corect
        Task removedTask = container.remove();
        if (!removedTask.Equals(task3))
        {
            throw new Exception("Test container removed task is not 3!");
        }
        
        removedTask = container.remove();
        if (!removedTask.Equals(task2))
        {
            throw new Exception("Test container removed task is not 2!");
        }
        
        removedTask = container.remove();
        if (!removedTask.Equals(task1))
        {
            throw new Exception("Test container removed task is not 1!");
        }
        
        //Verific daca containerul este gol
        if (container.isEmpty() == false)
        {
            throw new Exception("Test container is not empty!");
        }else
        {
            Console.WriteLine("success");
        }
    }

    private void testRunner1(string[] args)
    {
        //Test pentru StrategyTaskRunner
        Console.WriteLine("\nTest pentru StrategyTaskRunner:");
        
        //Verific daca am un argument
        if (args.Length == 0)
        {
            Console.WriteLine("Error: No strategy specified. Use FIFO or LIFO as arguments.");
            return;
        }
        
        // Determin strategia pe baza argumentului
        ContainerStrategy strategy;
        if (args[0].ToUpper() == "FIFO")
        {
            strategy = ContainerStrategy.FIFO;
            Console.WriteLine("*** Ai ales strategia FIFO ***");
        }
        else if (args[0].ToUpper() == "LIFO")
        {
            strategy = ContainerStrategy.LIFO;
            Console.WriteLine("*** Ai ales strategia LIFO ***");
        }
        else
        {
            Console.WriteLine("Error: Invalid strategy. Use FIFO or LIFO as arguments.");
            return;
        }
        
        //Creez un StrategyTaskRunner cu strategia specificata
        StrategyTaskRunner runner = new StrategyTaskRunner(strategy);
        
        //Adaug sarcini de tip MessageTask
        MessageTask[] tasks = createMessages();
        foreach (var task in tasks)
        {
            runner.addTask(task);
        }
        
        //Execut sarcinile
        Console.WriteLine($"Executing tasks using {strategy} strategy:");
        runner.executeAll();
    }

    private void testRunner2(string[] args)
    {
        //Test pentru StrategyTaskRunner
        Console.WriteLine("\nTest pentru StrategyTaskRunner + PrinterTaskRunner:");
        
        //Verific daca am un argument
        if (args.Length == 0)
        {
            Console.WriteLine("Error: No strategy specified. Use FIFO or LIFO as arguments.");
            return;
        }
        
        // Determin strategia pe baza argumentului
        ContainerStrategy strategy;
        if (args[0].ToUpper() == "FIFO")
        {
            strategy = ContainerStrategy.FIFO;
            Console.WriteLine("*** Ai ales strategia FIFO ***");
        }
        else if (args[0].ToUpper() == "LIFO")
        {
            strategy = ContainerStrategy.LIFO;
            Console.WriteLine("*** Ai ales strategia LIFO ***");
        }
        else
        {
            Console.WriteLine("Error: Invalid strategy. Use FIFO or LIFO as arguments.");
            return;
        }
        
        MessageTask[] tasks = createMessages();

        // Creez un obiect StrategyTaskRunner cu strategia aleasa
        StrategyTaskRunner strategyRunner = new StrategyTaskRunner(strategy);

        // Creez un obiect PrinterTaskRunner care decoreaza StrategyTaskRunner
        PrinterTaskRunner printerRunner = new PrinterTaskRunner(strategyRunner);

        // Adaug task-urile si le execut folosind PrinterTaskRunner
        Console.WriteLine("Executing tasks using PrinterTaskRunner with " + strategy + " strategy:");
        foreach (var task in tasks)
        {
            printerRunner.addTask(task);
        }
        printerRunner.executeAll();
    }

    private void testRunner3(string[] args)
    {
        //Test pentru StrategyTaskRunner
        Console.WriteLine("\nTest pentru StrategyTaskRunner + DelayTaskRunner + PrinterTaskRunner:");
        
        //Verific daca am un argument
        if (args.Length == 0)
        {
            Console.WriteLine("Error: No strategy specified. Use FIFO or LIFO as arguments.");
            return;
        }
        
        // Determin strategia pe baza argumentului
        ContainerStrategy strategy;
        if (args[0].ToUpper() == "FIFO")
        {
            strategy = ContainerStrategy.FIFO;
            Console.WriteLine("*** Ai ales strategia FIFO ***");
        }
        else if (args[0].ToUpper() == "LIFO")
        {
            strategy = ContainerStrategy.LIFO;
            Console.WriteLine("*** Ai ales strategia LIFO ***");
        }
        else
        {
            Console.WriteLine("Error: Invalid strategy. Use FIFO or LIFO as arguments.");
            return;
        }
        
        MessageTask[] tasks = createMessages();
        
        // Creez un obiect StrategyTaskRunner cu strategia aleasa
        StrategyTaskRunner strategyRunner = new StrategyTaskRunner(strategy);
        
        // Creez un obiect DelayTaskRunner care decoreaza StrategyTaskRunner
        DelayTaskRunner delayRunner = new DelayTaskRunner(strategyRunner);
        
        // Creez un obiect PrinterTaskRunner care decoreaza DelayTaskRunner
        PrinterTaskRunner printerRunner = new PrinterTaskRunner(delayRunner);

        // Adaug task-urile si le execut folosind PrinterTaskRunner
        Console.WriteLine("Executing tasks using PrinterTaskRunner with " + strategy + " strategy:");
        foreach (var task in tasks)
        {
            printerRunner.addTask(task);
        }
        printerRunner.executeAll();
    }

    public void runTests(string[] args)
    {
        testMessageTask();
        testSort();
        testContainerFIFO();
        testContainerLIFO();
        
        testRunner1(args);
        testRunner2(args);
        testRunner3(args);
    }
}
