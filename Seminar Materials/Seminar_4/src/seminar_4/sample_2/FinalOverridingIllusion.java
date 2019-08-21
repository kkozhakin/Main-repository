package seminar_4.sample_2;

// It only looks like you can override a private or private final method.
// TODO: explain - why there are warnings, and what's going on in main()-method (why commented calls cannot work...)

class WithFinals {

    // Print with a newline:
    public static void print(Object obj) {
        System.out.println(obj);
    }

    private void f() { print("WithFinals.f()"); }
    // Also automatically "final":
    private void g() { print("WithFinals.g()"); }
}

class OverridingPrivate extends WithFinals {
    private void f() {
        print("OverridingPrivate.f()");
    }
    private void g() {
        print("OverridingPrivate.g()");
    }
}

class OverridingPrivate2 extends OverridingPrivate {

    public final void f() {
        print("OverridingPrivate2.f()");
    }
    public void g() {
        print("OverridingPrivate2.g()");
    }
}

public class FinalOverridingIllusion {

    public static void main(String[] args) {
        OverridingPrivate2 op2 = new OverridingPrivate2();
        op2.f();
        op2.g();

    //  You can upcast:
        OverridingPrivate op = op2;
//      But you can't call the methods; todo - explain - why?:

//         op.f(); // !!!
//         op.g(); // !!!

    //  Same here:
        WithFinals wf = op2;

//         wf.f();
//         wf.g();
    }
}
