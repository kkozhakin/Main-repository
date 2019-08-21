package sample_3;

import java.awt.*;

public class ColorPoint1 extends Point {

    private final Color color;

    public ColorPoint1(int x, int y, Color color) {
        super(x, y);
        this.color = color;
    }
    // Remainder omitted ...
    //TODO: how to redefine equals()-method here?
    // TODO: If there is no redefinition then color is just ignored...

    // Following violates symmetry:
    @Override public boolean equals(Object o) {
        if (!(o instanceof ColorPoint1))
            return false;
        return super.equals(o) && ((ColorPoint1) o).color == color;
    }
}
