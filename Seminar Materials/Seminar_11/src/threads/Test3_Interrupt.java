package threads;

import java.util.Scanner;

class Test3_Interrupt {
    private Thread mainThread;
    private Thread t1;
    private Thread t2;

    private Test3_Interrupt(Thread main){
        this.mainThread = main;

        t1 = new Thread(){
            @Override
            public void run(){
//                System.out.println("this = " + this);
//                System.out.println("this.getClass() = " + this.getClass());

                Scanner scanner = new Scanner(System.in);
                String s = "enter something...";
                System.out.println("--> " + s);
                while (!(s = scanner.nextLine()).equals("exit")) {
                    if (Thread.currentThread().isInterrupted())
                        break;
                    System.out.println("--> " + s);
                }
                System.out.println("I am thread " + getName() + ": interrupted... ");
                mainThread.interrupt();
            }
        };
        t1.setName("t1");

        t2 = new Thread(
            () -> {
                System.out.println("this (in lambda) = " + this);
                System.out.println("this.getClass() [in lambda] = " + this.getClass());
                Thread t;
                long c1 = System.currentTimeMillis();
                while (!(t = Thread.currentThread()).isInterrupted()){
                    System.currentTimeMillis();
                }
                long c2 = System.currentTimeMillis();
                //TODO: answer - why t local variable is needed to access getName() method?
                // what is the difference - comparing with implementation of t1 using anonymous class?)
                // what id the difference between deriving an anonymous class from a class or from an (functional) interface?
                System.out.println("I am thread " + t.getName() + ": interrupted... (I worked " +(c2 - c1)+" ms.)");
            }
        );
        t2.setName("t2");
    }

    public static void main(String[] args) {
        Thread mainThread = Thread.currentThread();
        mainThread.setName("mainThread");

        Test3_Interrupt thisTest = new Test3_Interrupt(mainThread);
        thisTest.t1.start();
        thisTest.t2.start();
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ex){
            System.out.println("" + ex);
        }
        thisTest.t2.interrupt();
        thisTest.t1.interrupt();

        while (!Thread.currentThread().isInterrupted()){
            Thread.yield();
        }

        System.out.println("I am thread " + Thread.currentThread().getName() + ": finishing... ");
    }
}
