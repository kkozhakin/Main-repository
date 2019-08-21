package quiz;

import java.util.ArrayList;
import java.util.List;

class A{} // not used...

public class Question3 {
    public static void main(String[] args) {
        List<? super Integer> sList = new ArrayList<Number>();
        int i = 2018;
        sList.add(i);
        sList.add(++i);
//        Number num = sList.get(0); // sList could contain Comparable objects that cannot be assigned to Number...
    }
}
