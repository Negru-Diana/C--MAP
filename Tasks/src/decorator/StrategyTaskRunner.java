package decorator;

import factory.ContainerFactory;
import model.Container;
import model.Task;
import factory.TaskContainerFactory;
import factory.Strategy;

public class StrategyTaskRunner extends AbstractTaskRunner {
    //Implementeaza interfata TaskRunner

    private Container container;

    //Constructor
    public StrategyTaskRunner(Strategy strategy) {
        container=TaskContainerFactory.getInstance().createContainer(strategy);
    }

    //Suprascrie metoda executeOneTask() din interfata TaskRunner
    @Override
    public void executeOneTask() {
        if(!container.isEmpty()) {
            Task task = container.remove();
            if(task != null){
                task.execute();
            }
        }
    }

    //Suprascrie metoda executeAll() din interfata TaskRunner
    @Override
    public void executeAll() {
        while(hasTask()){
            executeOneTask();
        }
    }

    //Suprascrie metoda addTask() din interfata TaskRunner
    @Override
    public void addTask(Task t) {
        container.add(t);
    }

    //Suprascrie metoda hasTask() din interfata TaskRunner
    @Override
    public boolean hasTask() {
        return !container.isEmpty();
    }
}
