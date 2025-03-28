package factory;

import model.Container;
import sorter.AbstractSorter;
import sorter.SortStrategy;

public interface Factory {
    //Interfata pentru crearea containerelor de tip Container

    Container createContainer(Strategy strategy);

    /*
            * FACTORY METHOD PATTERN este un model de design utilizat în programarea orientată pe obiect, care se
        încadrează în categoria modelelor de creational. Acest model oferă o modalitate de a crea obiecte fără a
        specifica exact clasa de obiect care va fi creată.

            * CARACTERISTICI PRINCIPALE:
               1. ABSTRRACTIE: Factory Method oferă o interfață pentru crearea de obiecte, dar permite subclaselor să
        decidă ce clasă concretă să instanțieze. Acest lucru ajută la decuplarea codului client de implementarea
        concretă a obiectelor.
               2. SUBSTITUIREA: Clasele derivate pot modifica sau extinde comportamentul clasei de bază prin
        implementarea propriilor metode de creare de obiecte.
               3. EXTENSIBILITATE: Se poate adăuga cu ușurință noi tipuri de produse (obiecte) fără a modifica codul
        existent, făcând sistemul mai flexibil.

            * CUM FUNCTIONEAZA?
               1. INTERFATA CREATOR: Se definește o interfață (sau o clasă abstractă) care declară metoda de fabricație
        (createProduct()).
               2. IMPLEMENTAREA CREATORULUI: Clasele concrete (creatori) extind această interfață și implementează
        metoda de fabricație pentru a crea produse concrete.
               3. PRODUSE: Acestea sunt obiectele care sunt create prin metoda de fabricație. Aceste produse
        implementează o interfață comună.

     */
}
