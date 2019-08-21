//package sample_3;
//
//import java.awt.*;
//
//public class ColorPoint3 extends Point {
//
//    private final Color color;
//
//    public ColorPoint3(int x, int y, Color color) {
//        super(x, y);
//        this.color = color;
//    }
//    // Remainder omitted ...
//    //TODO: how to redefine equals()-method here?
//    // TODO: If there is no redefinition then color is just ignored...
//
//    // TODO: Broken - violates Liskov substitution principle:
//    @Override public boolean equals(Object o) {
//        if (o == null || o.getClass() != getClass())
//            return false;
//        Point p = (Point) o;
//        return p.x == x && p.y == y; //TODO: it requires package private access to x and y...
//    }
//}
