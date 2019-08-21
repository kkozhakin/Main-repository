package jmm;

/**
 * TODO: read the following explanation:
 * This sample id to demonstrate volatile keyword sense and usage.
 * The main thread starts another thread named "MyParallelThread" and tries to stop it after about 100 milliseconds.
 * The whole working time of "MyParallelThread" (without stopping it) is about 500 milliseconds (on my laptop).
 *
 * 1. Run the sample having volatile commented out.
 *    Observe that thread "MyParallelThread" finishes having n = 0,
 *    i.e. without any reaction on stop() invocation, that happens before the counter calculates to 0.
 *    (we can see that stop() was invoked before run() was finished - just compare "delta_t" duration with run duration)
 *
 * 2. Run the sample having volatile uncommented.
 *    Observe that thread "MyParallelThread" finishes almost immediately after stop() is invoked,
 *    before the counter calculates to 0.
 *
 * TODO: explain the volatile keyword influence on that behavior...
 */
public class Sample_1_volatile {

    public static void main(String[] args) {
        // start a parallel thread:
        MyRunnable runnable = new MyRunnable();
        Thread thread1 = new Thread(runnable);
        thread1.setName("MyParallelThread");
        thread1.start();

        try{
            Thread.sleep(100);
        } catch (InterruptedException ie){
            System.out.println("thread " + Thread.currentThread() + " interrupted.");
        }

        // and set active to false:
        runnable.stop();
    }
}

class MyRunnable implements Runnable
{
    private
    volatile //TODO: comment & uncomment this line (run without and with volatile keyword)
    boolean active = true;

    private long t0;

    public void run(){ // run is called in one thread
        t0 = System.nanoTime();
        long n = 999999999;
System.out.println("started... n = " + n + "; active = " + active);
        while (active){
        // some code here:
            n--;
            if (n == 0){
                break;
            }
        }
        System.out.println("thread " + Thread.currentThread() + " finished. n = " + n);
        System.out.println("run(): duration = " + (System.nanoTime() - t0));
    }

    void stop(){ // stop() is called from another thread
        active = false;
        System.out.println("stop(): delta_t = " + (System.nanoTime() - t0) + "; active = " + active);
    }
}