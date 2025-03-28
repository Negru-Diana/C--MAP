package decorator;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class PrinterTaskRunner extends AbstractTaskRunner {

   //Metoda statica pentru a formata ora
    private static final DateTimeFormatter TIME_FORMATTER = DateTimeFormatter.ofPattern("HH:mm");

    //Constructor
    public PrinterTaskRunner(TaskRunner taskRunner) {
        //Apeleaza constructorul clasei de baza AbstractTaskRunner
        super(taskRunner);
    }

    //Suprascrie metoda executeOneTask()
    @Override
    public void executeOneTask() {
        //Apeleaza metoda executeOneTask() din clasa de baza AbstractTaskRunner
        super.executeOneTask();
        //System.out.println("Task executed at: " + LocalDateTime.now().format(TIME_FORMATTER));
        System.out.println("Task executed at: " + LocalDateTime.now().format(TIME_FORMATTER));
    }
}
