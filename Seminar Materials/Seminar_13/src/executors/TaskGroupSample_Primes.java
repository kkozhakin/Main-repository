package executors;

import java.math.BigInteger;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorCompletionService;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class TaskGroupSample_Primes {
    private static final int N = 100; // the number of tasks;
    private static final int THREADS_IN_POOL = 4;  // the number of threads in pool. //todo; play with that number...

    static final long LONG_M = 100_000_000_000L;
    static final long LONG_INTERVAL = 100L;

    static final BigInteger M = BigInteger.valueOf(Long.MAX_VALUE).add(PrimeNumbers.ONE);
    static final BigInteger INTERVAL = BigInteger.valueOf(100);


    public static void main(String[] args) {
        System.out.println("Long.MAX_VALUE = " + Long.MAX_VALUE);

        ExecutorService service = Executors.newFixedThreadPool(THREADS_IN_POOL);
        ExecutorCompletionService<String> completionService = new ExecutorCompletionService<>(service);

        for (int i = 0; i < N; i++) {
            final int n = i;
            completionService.submit(() -> {
                long t0 = System.nanoTime();
//                BigInteger start = M.add(INTERVAL.multiply(BigInteger.valueOf(n)));
//                List<BigInteger> res = PrimeNumbers.listPrimesInInterval(start, INTERVAL);
                long start = LONG_M + n * LONG_INTERVAL;
                List<Long> res = PrimeNumbers.listPrimesInInterval(start, LONG_INTERVAL);
                long t1 = System.nanoTime();
                return Thread.currentThread() + "Task_" + n + " (" + (t1 - t0) / 1000000F + " msec): " + res; //todo:  find out - how to format properly...
//                return "Task_" + n +" (" + String.format("|%10d|", (t1 - t0)) + " nsec): " + res; //todo:  find out - how to format properly...
            });
        }
//service.shutdown(); // TODO: comment / uncomment...

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
