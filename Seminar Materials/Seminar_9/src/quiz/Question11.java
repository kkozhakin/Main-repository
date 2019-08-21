package quiz;

import java.util.Set;
import java.util.TreeSet;

class A_{}

public class Question11 {
    public static void main(String[] args) {
        Set set = new TreeSet<String>();
        set.add("one");
        set.add(2);
//        set.add("two");
        set.add("three");
        System.out.println(set);
    }
}
