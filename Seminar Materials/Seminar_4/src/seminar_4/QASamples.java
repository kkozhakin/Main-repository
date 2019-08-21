package seminar_4;

import java.lang.reflect.Method;
import java.util.Arrays;

public class QASamples {
}

class MyClass {
    public static void main(String[] args) {
        AA[] arrA;
        BB[] arrB;
        arrA = new AA[10];
        arrB = new BB[20];
        arrA = arrB;        // (1)
        arrB = (BB[]) arrA;  // (2)
        arrA = new AA[10];
        arrB = (BB[]) arrA;  // (3)
    }
}

class AA {}
class BB extends AA {}

class YingYang {
    void yingyang(Integer i) {
        System.out.println("Integer: " + i);
    }
//    void yingyang(Integer[] ints) {
//        System.out.println("Integer[]: " + ints[0]);
//    }
    void yingyang(Integer... ints) {
        System.out.println("Integer...: " + ints[0]);
    }
}
class RQ800A50 {
    public static void main(String[] args) {
        YingYang yy = new YingYang();
        yy.yingyang(10);
        yy.yingyang(10,12);
        yy.yingyang(new Integer[] {10, 20});
        yy.yingyang(new Integer(10), new Integer(20));
    }
}

class RQ800A20 {
    private static void compute(int... ia) { // (1)
        System.out.print("|");
        for(int i : ia) {
            System.out.print(i + "|");
        }
        System.out.println();
    }
    private static void compute(int[] ia1, int... ia2) { // (2)
        compute(ia1);
        compute(ia2);
    }
    private static void compute(int[] ia1, int[]... ia2d) { // (3)
        for(int[] ia : ia2d) {
            compute(ia);
        }
    }
    public static void main(String[] args) {
        compute(new int[] {10, 11}, new int[] {12, 13, 14}); // (4)
//        compute(new int[] {10, 11}, 12, 13, 14); // (4)
        compute(15, 16); // (5)
        compute(new int[] {17, 18}, new int[][] {{19}, {20}}); //(6)
        compute(null, new int[][] {{21}, {22}}); // (7)
    }
}

class Polymorphism2 {
    public static void main(String[] args) {
        A ref1 = new C();
        B ref2 = (B) ref1;
        System.out.println(ref2.g());
    }
}
class A {
    private int f() { return 0; }
    public int g() { return 3; }
}
class B extends A {
    private int f() { return 1; }
    public int g() { return f(); }
}
class C extends B {
    public int f() { return 2; }
}

//class ArrayCloneTest {
//    public static void main(String[] args) {
//        System.out.println(Arrays.toString(args.getClass().getMethods()));
//        System.out.println(Arrays.toString(args.getClass().getDeclaredMethods()));
//        String[] copy = args.clone();
//        Class c = args.getClass();
//        try{
//            Method cloneMethod = c.getDeclaredMethod("clone", new Class[0]);
//            System.out.println(cloneMethod);
//        } catch (Exception ex) {
//            System.out.println("ex = " + ex);
//        }
//    }
//}

class RQ200A70 {
    public static void main(String[] args) {
        Integer i = new Integer(-10);
        Integer j = new Integer(-10);
        Integer k = -10;
        System.out.print((i==j) + "|");
        System.out.print(i.equals(j) + "|");
        System.out.print((i==k) + "|");
        System.out.print(i.equals(k));
    }
}
