package ru.hse.edu.kgkozhakin;

import static org.junit.jupiter.api.Assertions.*;

class CountTest {

    private class TreadCount extends Thread {
        private int a;
        private double s;

        TreadCount(int a, double s){
            this.a = a;
            this.s = s;
        }

        public void run() { Main.Count(a, s); }
    }

    @org.junit.jupiter.api.Test
    void countTest() throws InterruptedException {

        TreadCount first, second;

        for (int i = 0; i < 10; i++) {
            first = new TreadCount(60, 5);
            second = new TreadCount(300, 4.5);

            first.start();
            second.start();

            first.join();
            second.join();

            assertEquals(Math.round(Main.x_0 * 10000000), 47500000);
            assertEquals(Math.round(Main.y_0 * 10000000), 4330127);

            Main.x_0 = 0;
            Main.y_0 = 0;
        }
    }
}