package factory;

import model.Container;
import model.QueueContainer;
import model.StackContainer;

public class TaskContainerFactory implements Factory {
    //Implementeaza interfata Factory folosind principiul Singleton

    private static TaskContainerFactory instance;

    //Constructor
    private TaskContainerFactory() {}

    //Metoda pentru a obtine instanta unei clase
    public static TaskContainerFactory getInstance(){
        if(instance == null){
            instance = new TaskContainerFactory();
        }
        return instance;
    }

    //Suprascrie metoda createContainer() din interfata Factory
    @Override
    public Container createContainer(Strategy strategy) {
        if(strategy == Strategy.FIFO){ //Creeaza si returneaza un container de tip FIFO
            return new QueueContainer();
        } else { //Creeaza si returneaza un container de tip LIFO
            return new StackContainer();
        }
    }
}
