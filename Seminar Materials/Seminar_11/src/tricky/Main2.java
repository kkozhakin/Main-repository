package tricky;

/**
 *  TODO: see Main1; why this Main2 does not work fine (synchronization problem)?
 *
 *  In Main #1: both threads are synchronized on the same (the single) object of Main class,
 *  and the mutual exclusion works fine.
 *
 *  In Main #2: there is no common object to have the threads synchronized on it:
 *  run() method is invoked for two different objects of the Main class (both created inside the for-loop),
 *  and the the mutual exclusion expected does not occur...
 */

public class Main2 implements Runnable {

    public static void main(String[] args){
        for (int i = 0; i < 2; i++){
            Thread t = new Thread(new Main2());
            t.start();
        }
    }

    @Override
    public void run() {
        Thread thread = Thread.currentThread();
        synchronized (this) {
            for (int i = 0; i < 5000; i++){
                System.out.println("thread " + thread + ": " + i);
                System.out.println(i);
            }
        }
    }
}
