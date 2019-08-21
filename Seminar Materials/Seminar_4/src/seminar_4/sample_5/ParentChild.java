package seminar_4.sample_5;

public class ParentChild {
}

class Parent {
    private int x;
    Parent(int x) {
        this.x = x;
    }
}

class Child extends Parent {
    private int y;
    Child (int y) {
        super(0);
        this.y = y;
    }
}