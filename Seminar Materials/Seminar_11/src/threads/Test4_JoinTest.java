package threads;

/**
 */
public class Test4_JoinTest {

    public static void main(String[] args){
        System.out.println("I am thread: " + Thread.currentThread());
        System.out.println("    my ThreadGroup: " + Thread.currentThread().getThreadGroup());
        System.out.println("    my Priority: " + Thread.currentThread().getPriority());

        Thread myFriendThread = new Thread(new Runnable(){
            @Override
            public void run() {
                System.out.println("I am thread: " + Thread.currentThread());
                System.out.println("    my ThreadGroup: " + Thread.currentThread().getThreadGroup());
                System.out.println("    my Priority: " + Thread.currentThread().getPriority());
                try{
//                    Thread.currentThread().sleep(10000);       //todo: show warning here...
                    Thread.sleep(1000);
                } catch(InterruptedException ie) {
                    System.out.println("InterruptedException: " + ie);
                }
                System.out.println("I am thread: " + Thread.currentThread() + " -> finishing...");
            }
        });

        System.out.println("myFriendThread.starting... ");
        myFriendThread.start();
        System.out.println("myFriendThread.started... ");

        long t1 = 0;
        long t2 = 0;
        try{
            System.out.println("myFriendThread.join() calling... t1 = " + (t1 = System.currentTimeMillis()));
            myFriendThread.join();
//            Thread.currentThread().join();
            System.out.println("myFriendThread.join() called... t2 = " + (t2 = System.currentTimeMillis()));
        }catch(InterruptedException ie){
            System.out.println("InterruptedException: "+ie);
        }
        System.out.println("I am " + Thread.currentThread().getName() + ": myFriendThread joined (t2 - t1) -> " + (t2 - t1));
    }
}
