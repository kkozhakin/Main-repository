package executors;

import java.util.Random;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorCompletionService;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 *  TODO: this short task can be provided as a class exercise.
 *
 *  Start N tasks with different Pi lengths parameters and print their results upon completion.
 *  Each task is to print Pi as string having a given length in digits.
 *  Pi digits are obtained from PiSpigot algorithm.
 */
public class TaskGroupSample_PI {

    private static final int N = 10; // the number of tasks;
    private static final int M = 1;  // the number of threads in pool. //todo; play with that number...

    public static void main(String[] args) {
        final Random random = new Random();
        ExecutorService service = Executors.newFixedThreadPool(M);
        ExecutorCompletionService<String> completionService = new ExecutorCompletionService<>(service);

        for (int i = 0; i < N; i++){
            final int n = i;
            final int digits = random.nextInt(N) + 10; // + 30; //i + N; //todo: play with that...
            completionService.submit(() -> {
                long t0 = System.nanoTime();
                String res = new PiSpigot(digits).result();
                long t1 = System.nanoTime();
                return "Task_" + n +" (" + (t1 - t0)/1000000F + " msec): " + res; //todo:  find out - how to format properly...
//                return "Task_" + n +" (" + (t1 - t0) + " nsec): " + res;
            });
        }
        for (int i = 0; i < N; i++){
            try {
                System.out.println(completionService.take().get());
            } catch (InterruptedException | ExecutionException e){
                System.out.println("got exception: " + e);
            }
        }
        service.shutdown(); // TODO: comment / uncomment...
    }
}
