package sample_3;

import java.awt.*;

public class Test {
    public static void main(String[] args) {
        test1();
        test2();
        test3();
    }

    private static void test1(){
        System.out.println("------------ symmetry ------------------------");
        // case 1 (see ColorPoint1 class)
        Point p1 = new Point(1, 1);
        Point p2 = new ColorPoint1(1, 1, Color.RED);
        System.out.println("p1.equals(p2) = " + p1.equals(p2));
        System.out.println("p2.equals(p1) = " + p2.equals(p1));
    }

    private static void test2(){
        System.out.println("------------ transitivity --------------------");
        // case 2 (see ColorPoint2 class)
        ColorPoint2 p1 = new ColorPoint2(1, 2, Color.RED);
        Point p2 = new Point(1, 2);
        ColorPoint2 p3 = new ColorPoint2(1, 2, Color.BLUE);
        System.out.println("p1.equals(p2) = " + p1.equals(p2));
        System.out.println("p2.equals(p3) = " + p2.equals(p3));
        System.out.println("p1.equals(p3) = " + p1.equals(p3));

    }

    private static void test3(){
        System.out.println("------------ substitution --------------------");
        /*
        any method written for the type should
        work equally well on its subtypes [Liskov].
        */

        Point1 point1 = new Point1(1, 0);
        System.out.println("Point1.onUnitCircle(point1) = " + Point1.onUnitCircle(point1));
        // TODO: find out - why it is false when hashCode()-methods is not redefined (or just delegates to super)...
        CounterPoint counterPoint = new CounterPoint(1, 0);
        System.out.println("Point1.onUnitCircle(counterPoint) = " + Point1.onUnitCircle(counterPoint));
        System.out.println("...............................................");

        Point2 point2 = new Point2(1, 0);
        System.out.println("Point2.onUnitCircle(point2) = " + Point2.onUnitCircle(point2));
        // TODO: find out - why it is false when hashCode()-methods is not redefined (or just delegates to super)...
        CounterPoint2 counterPoint2 = new CounterPoint2(1, 0);
        System.out.println("Point2.onUnitCircle(counterPoint) = " + Point2.onUnitCircle(counterPoint2));

    }
}
