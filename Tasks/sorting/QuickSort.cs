namespace Lab10.sorting;

public class QuickSort : AbstractSorter
{
    //Clasa QuickSort extinde clasa AbstractSorter
    
    // Suprascrie/Implementeaza metoda sort() din clasa AbstractSorter
    public override void sort(int[] array)
    {
        quickSort(array, 0, array.Length - 1);
    }
    
    private void quickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            //Obtin poziria pivotului
            int pivotIndex = partition(array, left, right);

            //Sortez recursiv
            quickSort(array, left, pivotIndex - 1); // Elemente mai mici decat pivotul
            quickSort(array, pivotIndex + 1, right); // Elemente mai mari decat pivotul
        }
    }
    
    private int partition(int[] array, int left, int right)
    {
        // Aleg ultimul element ca pivot
        int pivot = array[right];
        int i = left - 1; // Indice pentru elementele mai mici

        for (int j = left; j < right; j++)
        {
            // Daca elementul curent este <= pivotul
            if (array[j] <= pivot)
            {
                i++;
                // Schimb elementul curent cu cel de la pozitia i
                swap(array, i, j);
            }
        }

        // Schimb pivotul cu elementul de la pozitia i+1
        swap(array, i + 1, right);
        return i + 1; // Returnez pozitia pivotului
    }

    private void swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

}