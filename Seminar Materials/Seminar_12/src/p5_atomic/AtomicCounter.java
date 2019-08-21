package p5_atomic;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;

/**
 * Есть счетчик, подсчитывающий количество вызовов.
 * Почему счетчик показывает разные значения и не считает до конца?
 * Как это можно исправить не используя synchronized?
 * Попробуйте закомментировать обращение к yield().
 * Изменится ли значение?
 */

public class AtomicCounter {

    private int counter = 0;
    final AtomicInteger cnt = new AtomicInteger(0);

    class TestThreadRunnable implements Runnable {
        String threadName;

        TestThreadRunnable(String threadName) {
            this.threadName = threadName;
        }

        @Override
        public void run() {
            for (int i = 0; i < 10000 ; i++) {
                counter++;
//                cnt.getAndIncrement();

                Thread.yield();
            }
        }
    }


    public static void main(String[] args) {
        new AtomicCounter().testThread();
    }

    private void testThread() {
        List<Thread> threads = new ArrayList<>();
        for (int i = 0; i < 100; i++) {
            threads.add(new Thread(new TestThreadRunnable("t" + i)));
        }
        System.out.println("Starting threads");
        for (int i = 0; i < 100; i++) {
            threads.get(i).start();
        }
        try {
            for (int i = 0; i < 100; i++) {
                threads.get(i).join();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("Counter = " + counter);
//        System.out.println("Counter = " + cnt.get());
    }

}