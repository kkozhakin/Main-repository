package threads;

import java.util.Scanner;

public class Test1_Interrupt {

    public static void main(String[] args) {
        System.out.println("Thread " + Thread.currentThread() + " started.");
        Thread thread = new Thread(){
            @Override
            public void run() {
                System.out.println("Thread " + Thread.currentThread() + " started.");
                try {
                    while (!isInterrupted()){
                        myMethod();
                    }
                } catch (InterruptedException ie) {
                    System.out.println("got exception: " + ie);
                }
                System.out.println("Thread " + Thread.currentThread() + " finished.");
            }
        };
        thread.start();

        Scanner scan = new Scanner(System.in);
        scan.nextLine();
        thread.interrupt();
        System.out.println("Thread " + Thread.currentThread() + " finished.");
    }

    private static void myMethod() throws InterruptedException
    {

    }
}
