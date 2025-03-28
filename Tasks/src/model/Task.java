package model;

import java.util.Objects;

public abstract class Task {

    /*
         De ce trebuie sa fie clasa Task abstracta?

         --> Clasa Task reprezinta un concept generic de "task", iar abstractizarea acesteia permite definirea unei
         interfete comune pentru toate sarcinile derivate.
         --> Alte clase care extind Task pot reutiliza codul existent si pot adauga functionalitatea specifica.
         --> Metoda execute() este abstracta pentru a putea fi implementata de catre fiecare subclasa pentru nevoile
         sale, implementarea generica a acesteia nu ar avea sens.

         ==> Clasa Task este definită ca abstractă pentru a permite crearea de sarcini specifice, fiecare având o
         implementare particulară a metodei execute.
    */

    private String id;
    private String description;

    //Constructor
    public Task(String id, String description) {
        this.id = id;
        this.description = description;
    }

    //Getter id
    public String getId() {
        return id;
    }

    //Setter id
    public void setId(String id) {
        this.id = id;
    }

    //Getter description
    public String getDescription() {
        return description;
    }

    //Setter description
    public void setDescription(String description) {
        this.description = description;
    }

    //Metoda abstracta
    public abstract void execute();

    //Suprascrie metoda toString
    @Override
    public String toString() {
        return "Task{" +
                "id='" + id + '\'' +
                ", description='" + description + '\'' +
                '}';
    }

    //Suprascrie metoda equals
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Task task = (Task) o;
        return Objects.equals(id, task.id) && Objects.equals(description, task.description);
    }

    //Suprascrie metoda hashCode
    @Override
    public int hashCode() {
        return Objects.hash(id, description);
    }
}
