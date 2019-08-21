package fork_join_samples;

import java.util.concurrent.RecursiveAction;

// TODO: try to find threshold value and array length so that parallel execution gets 2 times faster than sequential...

public class SqrtTransform extends RecursiveAction {

    // The threshold value is arbitrarily set at 1,000 in this example.
    // In real-world code, its optimal value can be determined by profiling and experimentation.
    private static final int SEQ_THRESHOLD = 100_000_000; //30_000_000 ; //TODO: change to 10000000 and back to 90000000...
    // Array to be accessed.
    private double[] data;
    // Determines what part of data to process.
    private int start, end;

    SqrtTransform(double[] vals, int start, int end ) {
//    System.out.println("constructor(): " + Thread.currentThread() );
        data = vals;
        this.start = start;
        this.end = end;
    }
    // This is the method in which parallel computation will occur.
    protected void compute() {
//    System.out.println("compute(): " + Thread.currentThread() );
        // If number of elements is below the sequential threshold, then process sequentially.
        if((end - start) < SEQ_THRESHOLD) {
            // Transform each element into its square root.
            for(int i = start; i < end; i++) {
                data[i] = Math.sqrt(data[i]);
            }
        }
        else {
            // Otherwise, continue to break the data into smaller pieces. Find the midpoint.
            int middle = (start + end) / 2;
            // Invoke new tasks, using the subdivided data.
            invokeAll(new SqrtTransform(data, start, middle), new SqrtTransform(data, middle, end));
        }
    }
}

// Demonstrate parallel execution.
class ForkJoinDemo {
    public static void main(String args[]) {
        // todo: Create a task pool (as of JDK7), but it is not necessary in JDK8...
        // ForkJoinPool fjp = new ForkJoinPool();
//         ForkJoinPool fjp = ForkJoinPool.commonPool();

        double[] nums = new double[80000000];
//        double[] nums = new double[2000];
        // Give nums some values.
        for(int i = 0; i < nums.length; i++)
            nums[i] =  i;

        System.out.println("A portion of the original sequence:");
        for(int i = 0; i < 10; i++)
            System.out.print(nums[i] + " ");
        System.out.println("\n");

        SqrtTransform task = new SqrtTransform(nums, 0, nums.length);
        // Start the main ForkJoinTask.
        long t0 = System.currentTimeMillis(); //System.nanoTime();
//        fjp.invoke(task);
        task.invoke(); //todo: note that in JDK8 this starts execution using the common Fork-Join pool...
        long t1 = System.currentTimeMillis(); //System.nanoTime();

        System.out.println("total calculation time = " + (t1 - t0) + " (msec).");
        System.out.println("A portion of the transformed sequence (to four decimal places):");
        for(int i = 0; i < 10; i++)
            System.out.format("%.4f ", nums[i]);
        System.out.println();
    }
}