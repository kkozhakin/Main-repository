package enums;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.util.Scanner;

/**
 * TODO: explain the program functionality;
 * TODO: use it to analyse classes:
 *  - sample_2.reflection.ReflectionTest - i.e. it's own class:
 *  - sample_0.block_local.BlockLocalClassSample - as well as all other classes from that module / seminar...
 *  - sample_1.interface_impl.TalkingClock_v1
 *  - sample_1.interface_impl.TalkingClock_v2
 *  - sample_1.interface_impl.TalkingClock_v3
 *  - sample_1.interface_impl.TalkingClock_v4
 *  - sample_1.interface_impl.TalkingClock_v5
 *  - sample_1.interface_impl.TalkingClock_v6
 *  - sample_1.interface_impl.TalkingClock_v7 - this is lambda sample (to be discussed at the next lecture)
 *------------------------------------------------
 *  - sample_1.interface_impl.TalkingClock_v5$1TimePrinter
 *  - sample_1.interface_impl.TalkingClock_v6$1
 *  TODO: how we can read the value of the fields that had captured the environment in the classes above?
 *
 *  TODO: pay attention on synthetic fields that capture enclosing variables values for local & anonymous classes...
 */

public class ReflectionTest {

    private static String getClassName(){
        // read class name from command line args or user input
        String name;
        Scanner in = new Scanner(System.in);
        System.out.println("Enter fully qualified class name (or exit - to quit): ");
        name = in.next();
        return name;
    }

    public static void printClassInfo(Class cl){
        if (cl == null)
            return;
//        System.out.println(cl.toGenericString()); // JDK8(+)

        Class supercl = cl.getSuperclass();
        String modifiers = Modifier.toString(cl.getModifiers());
        if (modifiers.length() > 0)
            System.out.print(modifiers + " ");
        System.out.print("class " + cl.getName());
        if (supercl != null && supercl != Object.class)
            System.out.print(" extends " + supercl.getName());
        System.out.print(" {\n");
        printConstructors(cl);
        printMethods(cl);
        printFields(cl);
        printClasses(cl);
        System.out.println("}");
    }

    public static void main(String[] args) {
        String name;
        while ((name = getClassName()) != null){
            if (name.equalsIgnoreCase("exit")) {
                break;
            }
            Class cl;
            try {
                cl = Class.forName(name);
            } catch (ClassNotFoundException e) {
                //e.printStackTrace();
                System.err.println(e.toString());
                continue;
            }
            printClassInfo(cl);
        }
        System.exit(0);
    }
    /**
    * Prints all constructors of a class
    * @param cl a class
    */
    private static void printConstructors(Class cl) {
        Constructor[] constructors = cl.getDeclaredConstructors();
        System.out.println("constructors:");
        for (Constructor c : constructors) {
            String name = c.getName();
            System.out.print(" ");
            String modifiers = Modifier.toString(c.getModifiers());
            if (modifiers.length() > 0)
                System.out.print(modifiers + " ");
            System.out.print(name + "(");
            // print parameter types
            Class[] paramTypes = c.getParameterTypes();
            for (int j = 0; j < paramTypes.length; j++) {
                if (j > 0) System.out.print(", ");
                System.out.print(paramTypes[j].getName());
            }
            System.out.println(");");
        }
    }
    /**
    * Prints all methods of a class
    * @param cl a class
    */
    private static void printMethods(Class cl) {
        Method[] methods = cl.getDeclaredMethods();
        System.out.println("methods:");
        for (Method m : methods) {
            Class retType = m.getReturnType();
            String name = m.getName();
            System.out.print(" ");
            // print modifiers, return type and method name
            String modifiers = Modifier.toString(m.getModifiers());
            if (modifiers.length() > 0)
                System.out.print(modifiers + " ");
            System.out.print(retType.getName() + " " + name + "(");
            // print parameter types
            Class[] paramTypes = m.getParameterTypes();
            for (int j = 0; j < paramTypes.length; j++) {
                if (j > 0) System.out.print(", ");
                System.out.print(paramTypes[j].getName());
            }
            System.out.println(");");
        }
    }
    /**
    * Prints all fields of a class // TODO: print static fields with their values...
    * @param cl a class
    */
    private static void printFields(Class cl) {
        Field[] fields = cl.getDeclaredFields();
        System.out.println("fields:");
        for (Field f : fields) {
            Class type = f.getType();
            String name = f.getName();
            System.out.print(" ");
            String modifiers = Modifier.toString(f.getModifiers());
            if (modifiers.length() > 0)
                System.out.print(modifiers + " ");
            System.out.println(type.getName() + " " + name + ";");
        }
    }
    /**
     * Prints all classes of a class; TODO: show all info on nested/inner classes recursively...
     * @param cl a class
     */
    private static void printClasses(Class cl){
        Class[] classes = cl.getDeclaredClasses();
        System.out.println("classes:");
        for (Class c : classes) {
            String name = c.getName();
            System.out.print(" ");
            String modifiers = Modifier.toString(c.getModifiers());
            if (modifiers.length() > 0)
                System.out.print(modifiers + " ");
            System.out.println("class " + name + "{...};");
        }
    }
    /*
     * TODO: have a method to print value (object) with its' type info in some form. In what form it could be done?
     */
}
