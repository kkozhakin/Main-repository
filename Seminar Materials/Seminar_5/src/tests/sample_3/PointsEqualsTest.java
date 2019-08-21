package sample_3;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.awt.*;

import static org.junit.jupiter.api.Assertions.*;

public class PointsEqualsTest {
    @BeforeEach
    void setUp() {
        System.out.println("setUp()");
    }

    @AfterEach
    void tearDown() {
        System.out.println("tearDown()");
    }

    @Test
    void testCase1(){
        // case 1 (see ColorPoint1 class)
        Point p1 = new Point(1, 1);
        Point p2 = new ColorPoint1(1, 1, Color.RED);
        System.out.println("p1.equals(p2) = " + p1.equals(p2));
        assertEquals(p1, p2);
        System.out.println("p2.equals(p1) = " + p2.equals(p1));
        assertEquals(p2, p1);
    }

    @Test
    void testCase2(){
        ColorPoint2 p1 = new ColorPoint2(1, 2, Color.RED);
        Point p2 = new Point(1, 2);
        ColorPoint2 p3 = new ColorPoint2(1, 2, Color.BLUE);
        System.out.println("p1.equals(p2) = " + p1.equals(p2));
        System.out.println("p2.equals(p3) = " + p2.equals(p3));
        System.out.println("p1.equals(p3) = " + p1.equals(p3));
        assertEquals(p1, p2);
        assertEquals(p2, p3);
        assertEquals(p1, p3);
    }


}
