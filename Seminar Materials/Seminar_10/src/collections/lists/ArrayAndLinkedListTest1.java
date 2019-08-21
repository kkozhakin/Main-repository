package collections.lists;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;

/**
 */
public class ArrayAndLinkedListTest1 {

//    private static List<String> list = new LinkedList<>();        //    1656 msec
    private static List<String> list = new ArrayList<>();       //     110 msec

    private static String[] words = new String[1000];

    static {
        for(int i = 0; i < words.length; i++){
            words[i] = "word_" + i;
            list.add(words[i]);
        }
    }

    public static void main(String[] args){
        Random random = new Random(0);

        long t1 = System.currentTimeMillis();
        for (int i = 0; i < 1000000; i++){
            int index1 = (0x7FFFFFFF & random.nextInt()) % words.length;
            String s = list.get(index1);         // todo: DON'T USE that with LinkedList...
            int index2 = (0x7FFFFFFF & random.nextInt()) % words.length;
            list.set(index2, s);
        }
        long t2 = System.currentTimeMillis();
        System.out.print("t2 - t1 = " + (t2 - t1));
    }

}
