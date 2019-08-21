package quiz;

import java.util.ArrayList;
import java.util.List;

class C{}

public class Question9 {
    public static void main(String[] args) {
        List list = new ArrayList<String>();
        list.add(null);
        list.add("ok");
        list.add(2018);
//        String s = list.get(0);
        Object o = list.get(0);
    }
}
