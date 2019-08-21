package fork_join_samples;

import java.util.concurrent.ForkJoinPool;
import java.util.concurrent.RecursiveAction;

// A simple program that lets you experiment with the effects of
// changing the threshold and parallelism of a ForkJoinTask.
// A ForkJoinTask (via RecursiveAction) that performs a
// a transform on the elements of an array of doubles.

public class TestFJTransform extends RecursiveAction {

    // Sequential threshold, which is set by the constructor.
    int seqThreshold;
    // Array to be accessed.
    double[] data;
    // Determines what part of data to process.
    int start, end;

    TestFJTransform( double[] vals, int s, int e, int t ) {
        data = vals;
        start = s;
        end = e;
        seqThreshold = t;
    }

    // This is the method in which parallel computation will occur.
    protected void compute() {
        // If number of elements is below the sequential threshold, then process sequentially.
        if((end - start) < seqThreshold) {
        // The following code assigns an element at an even index the
        // square root of its original value. An element at an odd
        // index is assigned its cube root. This code is designed
        // to simply consume CPU time so that the effects of concurrent
        // execution are more readily observable.
            for(int i = start; i < end; i++) {
                if((data[i] % 2) == 0)
                    data[i] = Math.sqrt(data[i]);
                else
                    data[i] = Math.cbrt(data[i]);
            }
        }
        else {
        // Otherwise, continue to break the data into smaller pieces.
        // Find the midpoint.
            int middle = (start + end) / 2;
            // Invoke new tasks, using the subdivided data.
            invokeAll(
                    new TestFJTransform(data, start, middle, seqThreshold),
                    new TestFJTransform(data, middle,   end, seqThreshold)
            );
        }
    }
}

// Demonstrate parallel execution.
class FJExperiment {
    public static void main(String args[]) {
        int pLevel;
        int threshold;
        if(args.length != 2) {
            System.out.println("Usage: FJExperiment parallelism threshold ");
            return;
        }
        pLevel = Integer.parseInt(args[0]);
        threshold = Integer.parseInt(args[1]);
        // These variables are used to time the task.
        long beginT, endT;

        // Create a task pool. Notice that the parallelism level is set.
        ForkJoinPool fjp = new ForkJoinPool(pLevel);

        double[] nums = new double[1000000];
        for(int i = 0; i < nums.length; i++)
            nums[i] = (double) i;
        TestFJTransform task = new TestFJTransform(nums, 0, nums.length, threshold);
        // Starting timing.
        beginT = System.currentTimeMillis(); //System.nanoTime();
        // TODO: Start the main ForkJoinTask synchronously...
//        fjp.invoke(task); // task is executed synchronously...
        // TODO: Start the main ForkJoinTask asynchronously...
        fjp.execute(task); // task is executed asynchronously...
        while (!task.isDone()) {
            System.out.println(fjp);
        }
        // End timing.
        endT = System.currentTimeMillis(); //System.nanoTime();
        System.out.println("Level of parallelism: " + pLevel);
        int actualParallelizm = fjp.getParallelism();
        System.out.println("actualParallelizm = " + actualParallelizm);
        int availableProcessors = Runtime.getRuntime().availableProcessors();
        System.out.println("availableProcessors = " + availableProcessors);
        System.out.println("Sequential threshold: " + threshold);
//        System.out.println("Elapsed time: " + (endT - beginT) + " ns");
        System.out.println("Elapsed time: " + (endT - beginT) + " ms");
        System.out.println();
    }
}

class AutomateIt {
    public static void main(String[] args) {
        for (int i = 1; i <= 4; i++){
            FJExperiment.main(new String[]{ Integer.valueOf(i).toString(), "1000"});
        }
    }
}