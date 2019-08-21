package puzzler;

import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicInteger;

// TODO: guess - what will be printed?

public class Test1 {

    private final AtomicInteger counter = new AtomicInteger();

    public static void main(String[] args) {
        try {
            new Test1().run();
        } catch (Exception ex) {
            System.out.println("got exception: " + ex);
        }
        System.out.println("main(): finish...");
//        System.exit(0);
    }

    private void run() throws ExecutionException, InterruptedException {
        ExecutorService tpe = Executors.newFixedThreadPool(8);
        System.out.println("tpe = " + tpe);
        ForkJoinPool fjp = new ForkJoinPool();
        System.out.println("fjp = " + fjp);

//        Callable<Integer> callable = new Callable<Integer>() {
//            @Override
//            public Integer call() {
//                System.out.println("... in call(): thread = " + Thread.currentThread());
//                return counter.getAndIncrement();
//            }
//        };
        // todo: note - since Callable is a functional interface, we can replace the code above with lambda:
        Callable<Integer> callable = () -> {
            System.out.println("... in call(): thread = " + Thread.currentThread());
            return counter.getAndIncrement();
        };

        // todo: note - RecursiveTask is NOT a functional interface (abstract class), we cannot use lambda instead:
        RecursiveTask<Integer> task = new RecursiveTask<Integer>() {
            @Override
            protected Integer compute() {
                System.out.println("... in compute(): thread = " + Thread.currentThread());
                return counter.getAndIncrement();
            }
        };

        counter.set(0);
        for (int c = 0; c < 10; c++) {
//            System.out.print(tpe.submit(callable).get());
            System.out.println(tpe.submit(callable).get());
        }
        System.out.println("=> counter = " + counter.get());

        counter.set(0);
        for (int c = 0; c < 10; c++) {
//            System.out.print(fjp.submit(callable).get());
            System.out.println(fjp.submit(callable).get());
        }
        System.out.println("=> counter = " + counter.get());

        counter.set(0);
        for (int c = 0; c < 10; c++) {
//            System.out.print(fjp.submit(task).get());
            System.out.println(fjp.submit(task).get());
            //todo: note that without reinitialization task does not recalculate...
            task.reinitialize();
        }
        System.out.println("=> counter = " + counter.get());

        System.out.println("run(): finish...");
        // TODO: note that without shutdown() calls below the application does not exit (even after main() is finished):
        tpe.shutdown();
        fjp.shutdown();
    }
}

