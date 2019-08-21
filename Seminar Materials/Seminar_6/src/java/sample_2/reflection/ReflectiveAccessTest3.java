package sample_2.reflection;

/**
 * Using this technique, you can create an instance of any non-abstract class,
 * even if all its constructors are declared private.
 * For instance, below we create an instance of the Math class even though it is useless
 * since the Math class has no instance method. Still, it is possible to do it.
 */

//TODO: see warnings in console...(on JDK 9)!

public class ReflectiveAccessTest3 {

    public static void main(String[] args) throws Exception {
        Class cl = Class.forName("java.lang.Math");
        java.lang.reflect.Constructor[] c = cl.getDeclaredConstructors();
        c[0].setAccessible(true);
        Math mathInstance = (Math) c[0].newInstance((Object[])null);
        System.out.println(mathInstance);
    }
}