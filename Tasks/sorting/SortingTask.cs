using Task = Lab10.domain.Task;

namespace Lab10.sorting;

public class SortingTask : Task
{
    //Clasa SortingTask extinde clasa Task
    
    //Atribute
    private int[] numbers;
    private AbstractSorter sorter;
    private SortStrategy sortStrategy;
    
    //Constructor
    public SortingTask(string taskID, string descriere, int[] numbers, SortStrategy sortStrategy) : base(taskID, descriere)
    {
        this.numbers = numbers;
        this.sortStrategy = sortStrategy;
        this.sorter = chooseSorter(sortStrategy);
    }
    
    //Metoda pentru a determina strategia de sortare
    private AbstractSorter chooseSorter(SortStrategy sortStrategy)
    {
        return sortStrategy switch
        {
            SortStrategy.BUBBLE_SORT => new BubbleSort(),
            SortStrategy.QUICK_SORT => new QuickSort(),
            _ => throw new ArgumentException("Unsupported sort strategy: " + sortStrategy),
        };
    }
    
    // Suprascrie/Implementeaza metoda execute() din clasa Task
    public override void execute()
    {
        Console.WriteLine($"Sorting using strategy: {this.sortStrategy}");
        sorter.sort(numbers);
        Console.WriteLine("Sorted array: " + ArrayToString(numbers));
    }
    
    
    // Metoda pentru returnarea a unui array de numere sub forma de string
    private string ArrayToString(int[] numbers)
    {
        return string.Join(" ", numbers);
    }
}