package sample_2.reflection;

import java.lang.reflect.Field;

/**
 * Ok, the example is not really sexy.
 * Let's mess up a class that implements the Singleton pattern.
 * In the normal case, a singleton object is supposed to be the only instance of a given class.
 * To achieve this, we usually declare the class constructor private, so that no one can invoke it.
 * Well, as demonstrated below, with reflection we can bypass this restriction and create a second "singleton object".
 */

class ASingleton {
//    private static final ASingleton singleton = new ASingleton("I'm the only instance of class ASingleton");
    private static ASingleton singleton = new ASingleton("I'm the only instance of class ASingleton");
    public static synchronized ASingleton getInstance(){return singleton;}

    private String name;
    private ASingleton(String name) {
        this.name = name;
    }
    public String toString() {
        return this.name;
    }
}

public class ReflectiveAccessTest2 {

    public static void main(String[] args) throws Exception {
        Class cl = Class.forName("sample_2.reflection.ASingleton");
        java.lang.reflect.Constructor[] c = cl.getDeclaredConstructors();
        c[0].setAccessible(true);
        ASingleton anotherASingleton = (ASingleton) c[0].newInstance(new Object[]{"Not anymore!!"});
//        System.out.println(ASingleton.singleton);
        System.out.println(ASingleton.getInstance());
        System.out.println(anotherASingleton);

        Field mySingleton = cl.getDeclaredField("singleton");
        System.out.println("mySingleton = " + mySingleton);
        mySingleton.setAccessible(true);
        mySingleton.set(null, anotherASingleton); // TODO: note - it worked in earlier JDK (7 --)...???
        System.out.println(ASingleton.getInstance());
    }
}
