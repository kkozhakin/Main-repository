package exam803;

public class MyStuff {

    String name;

    MyStuff(String n) {
        name = n;
    }
    public static void main(String[] args) {
        MyStuff m1 = new MyStuff("guitar");
        MyStuff m2 = new MyStuff("tv");
        System.out.println(m2.equals(m1));

        System.out.println(m1.equals(null)); //Throws NPE instead of false result - equals() contract violated.
    }

    public boolean equals(Object o) {
        MyStuff m = (MyStuff) o;
        if (m.name != null) {
            return true;
        }
        return false;
    }
}