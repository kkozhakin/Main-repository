package collections.lists;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class ArrayAndLinkedListTest2 {

    private static List<String> list = new LinkedList<>();
//    private static List <String> list = new ArrayList<>();
    private static String[] words = new String[1000];

    static {
        for(int i = 0; i < words.length; i++){
            words[i] = "word_" + i;
        }
    }

    public static void main(String[] args){
        long t1 = System.currentTimeMillis();

        for (int i = 0; i < 1000; i++){
            for (int j = 0; j < words.length; j++){
                list.add(words[j]);
            }
            for (int j = 0; j < words.length; j++){
                list.remove(words[j]);
            }
        }
        long t2 = System.currentTimeMillis();
        System.out.print("t2 - t1 = " + (t2 - t1));
    }
}
