package quiz;

import com.sun.javafx.collections.MappingChange;

import java.util.HashMap;
import java.util.Map;

class B{}

public class Question7 {
    public static void main(String[] args) {
//        Map<Integer, Map<Integer, String>> map1 = new HashMap<Integer, HashMap<Integer,  String>>();
        Map<Integer, HashMap<Integer, String>> map2 = new HashMap<Integer, HashMap<Integer, String>>(); //ok
        Map<Integer, Integer> map3 = new HashMap<Integer, Integer>(); //ok
//        Map<? super Integer, ? super Integer> map4 = new HashMap<? super Integer, ? super Integer>>();
        Map<? super Integer, ? super Integer> map5 = new HashMap<Number, Number>(); //ok
        Map<? extends Number, ? extends Number> map6 = new HashMap<Number, Number>(); //ok
//        Map<?, ?> map7 = new HashMap<?, ?>();
    }
}

// b, c, e, f