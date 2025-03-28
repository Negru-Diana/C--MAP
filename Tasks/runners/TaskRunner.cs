using Task = Lab10.domain.Task;

namespace Lab10.runners;

public interface TaskRunner
{
    //Interfata specifica pentru o colectie de task-uri de executat

    void executeOneTask();
    void executeAll();
    void addTask(Task task);
    bool hasTask();
}