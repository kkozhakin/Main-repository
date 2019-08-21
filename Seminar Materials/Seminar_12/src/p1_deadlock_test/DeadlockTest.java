package p1_deadlock_test;

/**
 * TODO: start JConsole.exe and connect to this app to detect deadlock...
 */
public class DeadlockTest {

    public static void main(String[] args){
        Object a = "Resourse A";
        Object b = "Resourse B";

        Thread t1 = new Thread(new TestBehavior(a, b));
//        Thread t2 = new Thread(new TestBehavior(b, a));       //todo: show deadlock then change ...to fix...
        Thread t2 = new Thread(new TestBehavior(a, b));
        t1.start();
        t2.start();
    }
}

class TestBehavior implements Runnable {

    final private Object firstResourse;
    final private Object secondResourse;

//    int count = 0;

    //todo: how can we have an order for a set of objects? (see - System.identityHashCode()...)
    TestBehavior(Object o1, Object o2){
        firstResourse = o1;
        secondResourse = o2;
    }

    public void run() {
//        count = 0;
//        while (count++ < _15) {
        while(true){
            System.out.println(Thread.currentThread().getName() + " looking for lock on " + firstResourse);
            synchronized(firstResourse){
                System.out.println(Thread.currentThread().getName() + " obtained lock on " + firstResourse);

                System.out.println(Thread.currentThread().getName() + " looking for lock on " + secondResourse);
                synchronized(secondResourse){
                    System.out.println(Thread.currentThread().getName() + " obtained lock on " + secondResourse);

                    //simulate some time-consuming activity:
                    try{
                        System.out.println(Thread.currentThread().getName() + " falling asleep...");
                        Thread.sleep(100);
                        System.out.println(Thread.currentThread().getName() + " Good morning...");
                    }catch(InterruptedException ie){
                        System.err.println("Exception: " + ie);
                    }
                }
            }
        }
    }

    /*
    public static void main(String[] args){
        Object a = "Resourse A";
        Object b = "Resourse B";
        Thread t1 = new Thread(new TestBehavior(a, b));
//        Thread t1 = new Thread(new TestBehavior(b, a));
        Thread t2 = new Thread(new TestBehavior(b, a));
        t1.start();
        t2.start();
    }
    //*/
}
