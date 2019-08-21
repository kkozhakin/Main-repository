package fork_join_samples;

import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ForkJoinPool;
import java.util.concurrent.ForkJoinTask;

// TODO: read and try p1_path_samples here:  https://www.concretepage.com/java/jdk7/example-of-forkjoinpool-in-java
// TODO: read the paper: http://www.javacreed.com/java-fork-join-example/  или  https://github.com/javacreed/java-fork-join-example
public class Test_AdaptDemo {

    public static void main(String[] args) throws InterruptedException, ExecutionException {
        ForkJoinPool fjp = new ForkJoinPool();
        DemoTask task = new DemoTask();
        ForkJoinTask<String>  fjt = ForkJoinTask.adapt(task);
        fjp.invoke(fjt);
        System.out.println(fjt.isDone());
    }
}

class DemoTask implements Callable<String> {
    public String call() {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            System.out.println(e);
        }
        return "Task Done";
    }
}
