package sample_3;

import java.util.concurrent.atomic.AtomicInteger;

public class CounterPoint2 extends Point2 {

//    private static final AtomicInteger counter = new AtomicInteger();
//
//    public CounterPoint2(int x, int y) {
//        super(x, y);
//        counter.incrementAndGet();
//    }
//
//    public int numberCreated() {
//        return counter.get();
//    }

    public CounterPoint2(int x, int y){
        super(x, y);
        System.out.println("CounterPoint()-constructor invoked.");
    }
}
