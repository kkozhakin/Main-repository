package ru.hse.edu.kgkozhakin;

import java.time.LocalTime;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {

    static double x_0 = 0, y_0 = 0;
    static int StartTime = LocalTime.now().getSecond();

    public static void main(String[] args) {

        if (args.length == 2) {
            try {
                x_0 = Double.parseDouble(args[0]);
                y_0 = Double.parseDouble(args[1]);
            } catch (NumberFormatException e) {
                System.err.println("Неверный формат координат!");
                return;
            }
        }
        else if (args.length != 0 ) {
            System.err.println("Неверный формат координат!");
            return;
        }

        ExecutorService serv = Executors.newFixedThreadPool(4);
        serv.execute(() -> {
            try {
                while (LocalTime.now().getSecond() - StartTime < 25) {
                    System.out.format("x = " + "%.2f" + ", y = " + "%.2f\n", x_0, y_0);
                    Thread.sleep(2000);
                }
                System.out.format("Конечное положение: x = " + "%.2f" + ", y = " + "%.2f\n", x_0, y_0);
            }
            catch (InterruptedException ignored) { }
        });
        serv.execute(new Animal("Swan", 60));
        serv.execute(new Animal("Pike", 180));
        serv.execute(new Animal("Crawfish", 300));
        serv.shutdown();
    }

    static synchronized void Count(int a, double s) {
        x_0 += s * Math.cos(a * Math.PI / 180);
        y_0 += s * Math.sin(a * Math.PI / 180);
    }
}
