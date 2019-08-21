package sample_2.reflection;

/**
 *  Hack any Java class using Reflection
 *  TODO: see http://radio.javaranch.com/val/2004/_05/_18/1084891793000.html
 *
 *  Ever wondered what evil power can be unleashed when using reflection?
 *  Do you think private methods are really only accessible from within the declaring class?
 *  Do you think that a private field can only be modified from within the declaring class? No?
 *  That's what I thought!!
 *  In this blog, I will try to demonstrate that it is always important to correctly set the security properties
 *  of your applications.
 *  For instance, let's look at the following example where we successfully retrieve a private password
 *  from another class:
 */

class A {
    private static String getPassword() {
        return "someTopSecret";
    }
}

public class ReflectiveAccessTest1 {

    public static void main(String[] args) throws Exception {
//        System.setSecurityManager(new SecurityManager()); //TODO: comment/uncomment ...

        Class cl = Class.forName("sample_2.reflection.A");
        java.lang.reflect.Method[] m = cl.getDeclaredMethods();
        m[0].setAccessible(true);
        String password = (String) m[0].invoke(null, (Object[])null);
        System.out.println("I got it: " + password);
    }
}
