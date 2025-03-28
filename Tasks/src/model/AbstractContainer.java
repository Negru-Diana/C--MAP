package model;

import java.util.ArrayList;
import java.util.List;

public abstract class AbstractContainer implements Container {
    protected ArrayList<Task> tasks;

    public AbstractContainer() {
        this.tasks = new ArrayList<>();
    }

    @Override
    public void add(Task task) {
        tasks.add(task);
    }

    @Override
    public int size() {
        return tasks.size();
    }

    @Override
    public boolean isEmpty() {
        return tasks.isEmpty();
    }

    // Abstract method for removing tasks to be implemented by subclasses
    @Override
    public abstract Task remove();
}
