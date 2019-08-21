package seminar_3.sample_10;

/**
 * TODO: try to see - how calling System.sample_10() makes (or not?) difference...
 * TODO: try to force GC to work before the program exits...
 *
 *
 */
public class GCDemoTest {

    public static void main(String [] args) {
//        Vector<Dog> vector = new Vector<>();

        Dog one = new Dog("Bobick", 1);
        Dog two = new Dog("Guchka", 2);

//        vector.add(one);
//        vector.add(two);

        one = null;
        System.out.println("Calling sample_10 #1...");
        System.runFinalization();
        System.gc();

//        vector = null;
        System.out.println("Calling sample_10 #2...");
        System.runFinalization();
        System.gc();

        two = null;
        System.out.println("Calling sample_10 #3...");
        System.runFinalization();
        System.gc();
        System.out.println("End of main...");
    }
}
