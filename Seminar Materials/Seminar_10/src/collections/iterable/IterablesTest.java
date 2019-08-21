package collections.iterable;

import java.util.*;

/**
 * TODO: note, that arrays are NOT iterable but can be used with foreach-loops... Why - what do you think?
 * Iterable interface was added in JDK5 (along with for-each-loop)
 */
public class IterablesTest {

    private static int[] INT_ARRAY = new int[]{1, 2, 3, 4, 5, 6, 7, 8};
    private static List<Integer> MY_LIST = new ArrayList<>(8);

    static {
        for (int i = 0; i < 8; i++)
            MY_LIST.add(i);
    }

    public static void main(String[] args) {

        for (int i : INT_ARRAY) {
            System.out.print(i);
        }
        System.out.println();

        System.out.println(Arrays.toString(INT_ARRAY.getClass().getInterfaces()));
        System.out.println(Iterable.class.isAssignableFrom(int[].class));

        for (Integer i : MY_LIST) {
            System.out.print(i);
        }
        System.out.println();

        System.out.println(Iterable.class.isAssignableFrom(Collection.class));
        System.out.println(Iterable.class.isAssignableFrom(Vector.class));

        //test arrays loops:

    }
}

