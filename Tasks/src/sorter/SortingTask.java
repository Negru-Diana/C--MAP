package sorter;

import model.Task;

public class SortingTask extends Task {
    private int[] numbers;
    private AbstractSorter sorter;
    private SortStrategy sortStrategy;

    //Constructor
    public SortingTask(String id, String description, int[] numbers, SortStrategy strategy) {
        //Apelez constructorul clasei de baza Task
        super(id, description);
        this.numbers = numbers;
        this.sorter = chooseSorter(strategy);
    }

    //Determina tipul de sortare care trebuie folosit
    private AbstractSorter chooseSorter(SortStrategy sortStrategy) {
        switch (sortStrategy) {
            case BUBBLE_SORT:
                return new BubbleSort();
            case QUICK_SORT:
                return new QuickSort();
            default:
                throw new IllegalArgumentException("Unsupported sort strategy: " + sortStrategy);

        }
    }

    //Suprascrie/Implementeaza metoda execute() din clasa de baza
    @Override
    public void execute() {
        sorter.sort(numbers);
        System.out.println("Sorted array: " + arrayToString(numbers));
    }

    //Metoda de returnare a unui array de numere sub forma de string
    private String arrayToString(int[] numbers) {
        StringBuilder sb = new StringBuilder();
        for(int num : numbers){
            sb.append(num).append(" ");
        }
        return sb.toString();
    }
}
