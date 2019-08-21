package ru.hse.edu.kgkozhakin;

import static org.junit.jupiter.api.Assertions.*;

class AnimalTest {

    @org.junit.jupiter.api.Test
    void runTest() throws InterruptedException {
        Animal swan = new Animal("Swan", 60);
        double x = Main.x_0;
        double y = Main.y_0;
        swan.start();
        Thread.sleep(1);
        swan.stop();
        assertFalse(Math.abs(x - Main.x_0) < 0.00000001);
        assertFalse(Math.abs(y - Main.y_0) < 0.00000001);
        Main.x_0 = x;
        Main.y_0 = y;
    }
}