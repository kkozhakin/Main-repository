package threads;

public class Test2_Interrupt {

    private Thread t0;
    private Thread t1;

    private Test2_Interrupt(){
        t0 = new Thread(){
            @Override
            public void run() {
                System.out.println("I am thread " + getName() + ": beginning run() ...");
                while (!isInterrupted()){
                    //*
                    try{
                        System.out.println("I am thread " + getName() + ": going to sleep(10000)...");
                        Thread.sleep(10000);  //todo: read sleep(...) description...
                    }catch(InterruptedException ie){
                        System.out.println("I am thread " + getName() + ": got exception: " + ie);
//                        System.out.println("now isInterrupted() = " + isInterrupted());
//                        System.out.println("this = " + this);
                        Thread.currentThread().interrupt();    //TODO: first comment it out...then uncomment it...
                    }
                    //*/
                    /*
                    int i = 0;
                    while(i++ != 100000);
                    //*/
                }
                System.out.println("I am thread " + getName() + ": finishing run() having been interrupted...");
//                this.interrupt();
            }
        };

        t0.start();

        t1 = new Thread(){
            @Override
            public void run() {
//                super.run();
                // wait some time and interrupt t0...
                while(!isInterrupted()){
                    try{
                        System.out.println("I am thread " + getName() + ": going to sleep(5000)...");
                        sleep(5000);
                        System.out.println("I am thread " + getName() + ": calling t0.interrupt()...");
                        t0.interrupt();
                        System.out.println("t0.getState() = " + t0.getState());
                    }catch(InterruptedException ie){
                        System.out.println("I am thread " + getName() + ": got exception: " + ie);
                    }
                }
                System.out.println("I am thread " + getName() + ": finishing run()...");
            }
        };

        t1.start();
    }

    public static void main(String[] args){
        new Test2_Interrupt();
    }
}
