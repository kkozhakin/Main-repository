package sample_3;

import java.util.concurrent.atomic.AtomicInteger;

//TODO: note that the logic does not matter now, just any reason for inheritance...
//TODO: the code commented out shows a multithreaded variant (thread safe) of instance counting...

public class CounterPoint extends Point1 {
//    private static final AtomicInteger counter = new AtomicInteger();
//
//    public CounterPoint(int x, int y) {
//        super(x, y);
//        counter.incrementAndGet();
//    }
//
//    public int numberCreated() {
//        return counter.get();
//    }

    public CounterPoint(int x, int y){
        super(x, y);
        System.out.println("CounterPoint()-constructor invoked.");
    }
}
