package model;

import java.util.ArrayList;
import java.util.List;

//public class StackContainer implements Container {
public class StackContainer extends AbstractContainer {
    //Implementeaza o strategie de tip LIFO folosind o reprezentare pe un array
    // LIFO = Last In First Out


    public StackContainer() {
        super();
    }

    //Suprascrie metoda reomve() din interfata Container
    @Override
    public Task remove() {
        if(!tasks.isEmpty()){
            return tasks.remove(tasks.size()-1);
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
