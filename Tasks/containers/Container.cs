using Task = Lab10.domain.Task;

namespace Lab10.containers;

public interface Container
{
    Task remove();
    void add(Task task);
    int size();
    bool isEmpty();
}