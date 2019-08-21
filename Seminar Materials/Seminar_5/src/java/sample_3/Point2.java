package sample_3;

import java.util.HashSet;
import java.util.Set;

public class Point2 {
    // Initialize UnitCircle to contain all Points on the unit circle
    private static final Set<Point2> unitCircle;
    static {
        unitCircle = new HashSet<Point2>();
        unitCircle.add(new Point2( 1, 0));
        unitCircle.add(new Point2( 0, 1));
        unitCircle.add(new Point2(-1, 0));
        unitCircle.add(new Point2( 0, -1));
    }
    public static boolean onUnitCircle(Point2 p) {
        return unitCircle.contains(p);
    }

    final int x;
    final int y;

    public Point2(int x, int y) {
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
        if (!(o instanceof Point2))
            return false;
        Point2 p = (Point2) o;
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
