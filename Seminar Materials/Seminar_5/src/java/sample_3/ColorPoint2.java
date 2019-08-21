package sample_3;

import java.awt.*;

public class ColorPoint2 extends Point{
    private final Color color;

    public ColorPoint2(int x, int y, Color color) {
        super(x, y);
        this.color = color;
    }
    // Remainder omitted ...
    //TODO: how to redefine equals()-method here?
    // TODO: If there is no redefinition then color is just ignored...

    // TODO: Broken - violates transitivity! Test it...
    @Override
    public boolean equals(Object o) {
        if (!(o instanceof Point))
            return false;
// If o is a normal Point, do a color-blind comparison
        if (!(o instanceof ColorPoint2))
            return o.equals(this);
// then o is a ColorPoint; do a full comparison
        return super.equals(o) && ((ColorPoint2) o).color == color;
    }
}
