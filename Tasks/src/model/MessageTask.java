package model;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class MessageTask extends Task{
    private String message;
    private String from;
    private String to;
    private LocalDateTime date;

    //Metoda statica pentru obtinerea formatului de data
    public static DateTimeFormatter getDateFormatter(){
        return dateFormatter;
    }

    //Crearea unei instante statice pentru a formata datele
    private static final DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm");

    //Constructor
    public MessageTask(String taskId, String description, String message, String from, String to, LocalDateTime date) {
        super(taskId, description);
        this.message = message;
        this.from = from;
        this.to = to;
        this.date = date;
    }

    //Suprascrie metoda execute() din clasa Task
    @Override
    public void execute() {
        System.out.println(date.format(dateFormatter) + ": " + message);
    }

    //Suprascrie metoda toString()
    @Override
    public String toString() {
        return "id = " + getId() +
                " | description = " + getDescription() +
                " | message = " + message +
                " | from = " + from +
                " | to = " + to +
                " | date = " + date.format(dateFormatter);
    }
}
