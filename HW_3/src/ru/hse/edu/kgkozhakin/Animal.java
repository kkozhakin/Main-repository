package ru.hse.edu.kgkozhakin;

import java.time.LocalTime;

public class Animal extends Thread {
    private int a;

    Animal(String name, int a) {
        setName(name);
        this.a = a;
    }

    @Override
    public void run() {
        try {
            while (LocalTime.now().getSecond() - Main.StartTime < 25) {
                Main.Count(a, Math.random() * 10);
                Thread.sleep(1000 + (int) (Math.random() * 5000));
            }
        } catch (InterruptedException ignored) { }
    }
}
