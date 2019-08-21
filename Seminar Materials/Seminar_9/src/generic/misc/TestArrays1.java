package generic.misc;

import java.lang.reflect.Array;
import java.util.Arrays;

class TA{}

class TB
//    extends TA
    {}

//TODO: 1) show ArrayStoreException... then 2) chane class TB extends TA {} - just uncomment - and feel the difference...

public class TestArrays1 {
    private static Object[] objects = (Object[]) Array.newInstance(TA.class, 5);

    public static void main(String[] args){
        System.out.println("objects = " + Arrays.toString(objects));
        objects[3] = new TB(); //TODO: note that compiler cannot catch the error (why?), but runtime check does it...

        System.out.println("objects = " + Arrays.toString(objects));
    }
}
