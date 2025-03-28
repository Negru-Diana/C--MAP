
import decorator.PrinterTaskRunner;
import decorator.StrategyTaskRunner;
import decorator.TaskRunner;
import factory.Strategy;
import model.MessageTask;
import sorter.AbstractSorter;
import sorter.BubbleSort;
import tests.Test;

import java.time.LocalDateTime;

public class Main {


    public static void main(String[] args) {

        Test test = new Test();
        test.executeAll(args);

    }
}