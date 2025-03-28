package tests;

import decorator.DelayTaskRunner;
import decorator.PrinterTaskRunner;
import decorator.StrategyTaskRunner;
import decorator.TaskRunner;
import factory.Strategy;
import model.MessageTask;
import sorter.SortStrategy;
import sorter.SortingTask;
import model.Task;
import factory.TaskContainerFactory;
import model.Container;

import java.time.LocalDateTime;

public class Test {

    // Cerinta 4 - program de test care creeaza un vector de 5 task-uri de tip MessageTask
    private static MessageTask[] createMessages() {
        MessageTask msg1 = new MessageTask("1","feedback lab 2","Te-ai descurcat bine 1","teacher","student", LocalDateTime.now());
        MessageTask msg2 = new MessageTask("2","feedback lab 3","Te-ai descurcat bine 2","teacher","student",LocalDateTime.now());
        MessageTask msg3 = new MessageTask("3","feedback lab 4","Te-ai descurcat bine 3","teacher","student",LocalDateTime.now());
        MessageTask msg4 = new MessageTask("4","feedback lab 5","Te-ai descurcat bine 4","teacher","student",LocalDateTime.now());
        MessageTask msg5 = new MessageTask("5","feedback lab 6","Te-ai descurcat bine 5","teacher","student",LocalDateTime.now());

        return new MessageTask[]{msg1,msg2,msg3,msg4,msg5};
    }

    private void testeSeminar(String[] args){
        // Cerinta 4 - test MessageTask
        System.out.println("Test MessageTask:");
        MessageTask[] messageTasks = createMessages();
        for(MessageTask messageTask : messageTasks) {
            System.out.println(messageTask);
        }

        // Cerinta 10 - test StrategyTaskRunner (decorator)
        System.out.println("\nTest TaskRunner:");
        TaskRunner strategyTaskRunner = new StrategyTaskRunner(Strategy.valueOf(args[0]));
        for(MessageTask m : messageTasks) {
            strategyTaskRunner.addTask(m);
        }
        strategyTaskRunner.executeAll();


        // Cerinta 13 - test PrinterTaskRunner (decorator)
        System.out.println("\nTest PrinterTaskRunner:");
        TaskRunner strategyTaskRunner2 = new StrategyTaskRunner(Strategy.valueOf(args[0]));
        for(MessageTask m : messageTasks) {
            strategyTaskRunner2.addTask(m);
        }
        TaskRunner printerTaskRunner = new PrinterTaskRunner(strategyTaskRunner2);
        printerTaskRunner.executeAll();
    }

    private static void testSort(){
        int[] numbers={5,3,8,4,2};

        //BubbleSort
        System.out.println("\nTest BubbleSort (1):");
        Task bubbleSortTask = new SortingTask("1","Bubble Sort", numbers.clone(), SortStrategy.BUBBLE_SORT);
        bubbleSortTask.execute();

        //QuickSort
        System.out.println("\nTest QuickSort (1):");
        Task quickSort = new SortingTask("2","Quick Sort", numbers.clone(), SortStrategy.QUICK_SORT);
        quickSort.execute();

        int[] numbers2={5,4,3,2,1};

        //BubbleSort
        System.out.println("\nTest BubbleSort (2):");
        Task bubbleSort = new SortingTask("3","Bubble Sort", numbers2,SortStrategy.BUBBLE_SORT);
        bubbleSort.execute();

        //QuickSort
        System.out.println("\nTest QuickSort (2):");
        Task quickSortTask = new SortingTask("4","Quick Sort", numbers2,SortStrategy.QUICK_SORT);
        quickSortTask.execute();
    }

    private void testDelay(String[] args){
        System.out.println("\nTest DelayTaskRunner:");
        MessageTask[] messageTasks = createMessages();
        for(MessageTask messageTask : messageTasks) {
            System.out.println(messageTask);
        }

        TaskRunner strategy = new StrategyTaskRunner(Strategy.valueOf(args[0]));
        for(MessageTask m : messageTasks) {
            strategy.addTask(m);
        }
        TaskRunner runner = new PrinterTaskRunner(strategy);
        runner=new DelayTaskRunner(runner);
        runner.executeAll();
    }


    public void executeAll(String[] args){
        testeSeminar(args); //testeaza MessageTask, StrategyTaskRunner si PrinterTaskRunner
        testSort(); //testeaza strategiile de sortare: BubbleSort si QuickSort
        testDelay(args); //testeaza DelayTaskRunner
    }
}
