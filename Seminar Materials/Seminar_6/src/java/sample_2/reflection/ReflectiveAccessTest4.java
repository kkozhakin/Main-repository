package sample_2.reflection;

/**
 * Finally, let's mess with the Runtime class which has one private static field
 * for storing the current Runtime instance.
 * This is another example of a badly implemented singleton class. Let's look at the code below.
 * We first retrieve the current runtime object and display it (3-4).
 * Then, we set the Runtime.currentRuntime static field to null,
 * which means that all successive calls to Runtime.getRuntime() will yield null (6-9)
 * since currentRuntime is initialized at class loading time.
 * We then get the currentRuntime field again and display its value (_11-_12).
 * And finally, we try to use the current runtime to execute a b6_command for displaying
 * the content of the current directory (_14). The output talks for itself.
 *
 * TODO: Read below:
 * All this could have been avoided if the currentRuntime field had been declared final.
 * Nothing prevents setAccessible(true) to be called on the field (8) but when the set(null, null) method is called,
 * IllegalAccessException is thrown with the message "Field is final".
 *
 * I'm pretty sure that there is a huge amount of code out there that could be broken this way. Watch out!!
 * Bottom line:
 * singleton fields should always be declared private static final!!!
 * Moreover, make sure you never grant ReflectPermission and RuntimePermission.accessDeclaredMembers
 * in the java.policy file of your production code.
 */

//TODO: see warnings and exception in console...(on JDK 9)!

public class ReflectiveAccessTest4 {
        String s;
    public static void main(String[] args) throws Exception {

        ReflectiveAccessTest4 t = new ReflectiveAccessTest4();
        System.out.println(t.s);

        Runtime r = Runtime.getRuntime();
        System.out.println("Before: Runtime.getRuntime() yields " + r);

        Class cl = Class.forName("java.lang.Runtime");
        java.lang.reflect.Field f = cl.getDeclaredField("currentRuntime");
        f.setAccessible(true);
        f.set(null, null);

        r = Runtime.getRuntime();
        System.out.println("After: Runtime.getRuntime() yields " + r);

        r.exec("dir"); //raises NullPointerException!!
    }
}