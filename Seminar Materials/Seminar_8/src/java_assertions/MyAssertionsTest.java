package java_assertions;

/**
 * TODO: play with -ea / -da JVM options...
 */
public class MyAssertionsTest {

    public static void main(String[] args){
        double x = 0;
        double y = mySinus(x);
        assert y <= 1 : "wrong result:" + y;
    }

    private static double mySinus(double x) {
        return Math.sin(x) + 2;
    }
}
