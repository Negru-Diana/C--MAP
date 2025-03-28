package sorter;

public class QuickSort extends AbstractSorter {

    //Suprascrie/Implementeaza metoda sort(int[] array) din clasa AbstractSorter
    @Override
    public void sort(int[] array) {
        quickSort(array, 0, array.length - 1);
    }

    private void quickSort(int[] array, int left, int right) {
        if(left < right) {
            //Obtin pozitia pivotului
            int pivotPoz = partition(array, left, right);

            //Sortez recursiv subtablourile
            quickSort(array, left, pivotPoz-1); //Elemente mai mici decat pivotul
            quickSort(array, pivotPoz+1, right); //Elemente mai mari decat pivotul
        }
    }

    private int partition(int[] array, int left, int right) {
        //Aleg ultimul element ca si pivot
        int pivot=array[right];
        int i=(left-1); //Indice pentru elemente mai mici

        for(int j=left;j<right;j++){
            //Daca elementul curent este <= cu pivot
            if(array[j]<=pivot){
                i++;
                //Schimb elementul curent cu cel de la pozitia i
                swap(array,i,j);
            }
        }

        //Schimb pivotul cu elementul de la pozitia i+1
        swap(array,i+1,right);
        return i+1; //Returnez pozitia pivotului
    }

    private void swap(int[] array, int i, int j) {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
