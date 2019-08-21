package sample_3;

import java.util.HashSet;
import java.util.Set;

public class Point1 {
    // Initialize UnitCircle to contain all Points on the unit circle
    private static final Set<Point1> unitCircle;
    static {
        unitCircle = new HashSet<Point1>();
        unitCircle.add(new Point1( 1, 0));
        unitCircle.add(new Point1( 0, 1));
        unitCircle.add(new Point1(-1, 0));
        unitCircle.add(new Point1( 0, -1));
    }
    public static boolean onUnitCircle(Point1 p) {
        return unitCircle.contains(p);
    }

    final int x;
    final int y;

    public Point1(int x, int y) {
        this.x = x;
        this.y = y;
    }

    // TODO: Broken - violates Liskov substitution principle:
        /*
        Any method written for the type should
        work equally well on its subtypes [Liskov].
        */

    @Override
    public boolean equals(Object o) {
        if (o == null || o.getClass() != getClass())
            return false;
        Point1 p = (Point1) o;
        return p.x == x && p.y == y;
    }
    // Remainder omitted...
    @Override
    public int hashCode(){
        System.out.println("Point1.hashCode() invoked...");
//        return super.hashCode();
        return 1;
    }


}
