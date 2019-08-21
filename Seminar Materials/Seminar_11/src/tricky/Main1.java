package tricky;

/**
 *  TODO: guess - why Main1 works fine while Main2 - does not...
 */
public class Main1 implements Runnable {

    public static void main(String[] args){
        Main1 main = new Main1();
        for (int i = 0; i < 2; i++){
            Thread t = new Thread(main);
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

