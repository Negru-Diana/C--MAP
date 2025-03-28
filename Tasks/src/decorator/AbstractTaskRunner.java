package decorator;

import model.Task;

public abstract class AbstractTaskRunner implements TaskRunner {
    //Implementeaza interfata TaskRunner

    protected TaskRunner taskRunner;

    //Constructori
    public AbstractTaskRunner(TaskRunner taskRunner) {
        this.taskRunner = taskRunner;
    }
    public AbstractTaskRunner() {
        this.taskRunner = null;
    }

    //Suprescrie metoda executeOneTask() din interfata TaskRunner
    @Override
    public void executeOneTask() {
        taskRunner.executeOneTask();
    }

    //Suprescrie metoda executeAll() din interfata TaskRunner
    @Override
    public void executeAll() {
        while(hasTask()){
            executeOneTask();
        }
    }

    //Suprescrie metoda addTask(Task t) din interfata TaskRunner
    @Override
    public void addTask(Task t) {
        taskRunner.addTask(t);
    }

    //Suprescrie metoda hasTask() din interfata TaskRunner
    @Override
    public boolean hasTask() {
        return taskRunner.hasTask();
    }

    /*
               * DECORATOR PATTERN este un model de design structural care permite adăugarea dinamică de comportamente
         sau responsabilități suplimentare la un obiect, fără a afecta alte obiecte din același tip. Acest model este
         utilizat adesea pentru a extinde funcționalitatea unui obiect existent în mod flexibil și reutilizabil.

               * CARACTERISTICI PRINCIPALE:
                  1. FLEXIBILITATE: Permite adăugarea sau eliminarea responsabilităților dintr-un obiect în timpul
          execuției. Astfel, se pot crea combinații diferite de comportamente pentru un obiect.
                  2. COMPOZITIE: Utilizând decoratorii, se poate realiza compunerea funcționalităților prin învăluirea
          (wrapping) obiectelor originale. Aceasta oferă o modalitate eficientă de a extinde funcționalitățile printr-o
          structură ierarhică.
                  3. SEPARAREA RESPONSABILITATILOR: Decoratorii pot gestiona funcționalități suplimentare, permițându-le
          obiectelor originale să rămână simple și concentrat pe sarcinile lor principale.

               * CUM FUNCTIONEAZA?
                  1. COMPONENTA: Este o interfață sau o clasă abstractă care definește un comportament comun pentru
           obiectele care vor fi decorate.
                  2. OBIECTE CONCRET: Clasele care implementează componenta, care conțin funcționalitățile de bază.
                  3. DECORATOR: O clasă abstractă care implementează componenta și conține o referință către un obiect
           de tip componentă. Aceasta permite decoratorilor să adauge comportamente noi.
                  4. DECORATORI CONCRETI: Clase care extind decoratorul și adaugă funcționalități suplimentare.
     */
}
