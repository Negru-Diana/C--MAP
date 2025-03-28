package model;

import java.util.ArrayList;
import java.util.List;

//public class QueueContainer implements Container {
public class QueueContainer extends AbstractContainer {
    //Implementeaza o strategie de tip FIFO folosind o reprezentare pe un array
    // FIFO = First In First Out

    public QueueContainer() {
        super();
    }

    //Suprascrie metoda reomve() din interfata Container
    @Override
    public Task remove() {
        if(!tasks.isEmpty()) {
            return tasks.remove(0);
        } else {
            return null;
        }
    }


//    //Suprascrie metoda add(Task task) din interfata Container
//    @Override
//    public void add(Task task) {
//        tasks.add(task);
//    }
//
//    //Suprascrie metoda size() din interfata Container
//    @Override
//    public int size() {
//        return tasks.size();
//    }
//
//    //Suprascrie metoda isEmpty() din interfata Container
//    @Override
//    public boolean isEmpty() {
//        return tasks.isEmpty();
//    }
}
