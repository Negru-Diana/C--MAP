package model;

public interface Container {
    //Interfata comuna pentru colectii de obiecte Task

    Task remove();
    void add(Task task);
    int size();
    boolean isEmpty();
}
