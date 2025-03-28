namespace Lab10.sorting;

public class BubbleSort : AbstractSorter
{
    //Clasa BubbleSort extinde clasa AbstractSorter
    
    // Suprascrie/Implementeaza metoda sort() din clasa AbstractSorter
    public override void sort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Schimbă elementele
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}