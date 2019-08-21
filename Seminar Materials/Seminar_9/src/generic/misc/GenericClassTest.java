package generic.misc;

//TODO: show why the Class<T> class is generic...See <Class>.casr() - method...
//TODO: set command line args? e.g.: java.lang.Comparable java.lang.String

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Random;

public class GenericClassTest {
    public static void main(String[] args) {

        // 1. T cast(Object o) - method:
        try {
            Class c = Class.forName(args[0]);
            Object o = c.cast(Class.forName(args[1]).newInstance());
            System.out.println(o.getClass());
        } catch (ClassCastException | ClassNotFoundException | IllegalAccessException | InstantiationException e){
            System.out.println("got exception: " + e);
        }

        // 2. saving a cast(s) when using parameterised Class<T>:
        try {
            int n = new Random().nextInt(4) + 1; // to avoid statically known value (warning);
            Class<?> c = Class.forName(args[1]);         // to avoid statically known value (warning):
            List<?> myRepeated = repeat(n, c);
            printNumberedCollectionElements(myRepeated);
        } catch (ReflectiveOperationException re) {
            System.out.println("got exception: " + re);
        }

    }
    private static <T> List<T> repeat(int n, Class<T> tClass) throws ReflectiveOperationException {
        ArrayList<T> result = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            result.add(tClass.getConstructor().newInstance()); // here the compiler knows T and the code creates elements of the type needed...
        }
        return result;
    }
    private static void printNumberedCollectionElements(Collection<?> collection){
        int i = 0;
        for (Object o : collection)
            System.out.println((i++) + ": " + o);
    }
}
