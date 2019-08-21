package threads;

public class Test0 implements Runnable {

    public void run() {
        double calc;
        for (int i = 0; i < 50000; i++) {
            calc = Math.sin( i * i);
            if ( i % 10000 == 0) {
                System.out.println(getName() + " counts " + i/10000);
            }
        }
    }

    public String getName() {
        return Thread.currentThread().getName();
    }

    //todo: note - the order of prints is different from time to time...
    public static void main(String s[]) {
        // Creating threads
        Thread t[] = new Thread[3];
        for (int i = 0; i < t.length; i++) {
            t[i] = new Thread( new Test0(), "Thread " + i);
        }
        // Starting threads
        for (int i = 0; i < t.length; i++) {
            t[i].start();
            System.out.println(t[i].getName() + " started");
        }
    }
}
