package quiz;

import java.util.ArrayList;
import java.util.List;

class A20{}

public class Question20 {
    public static <E extends Number> List<E> justDoIt(List<? super E> nums) {
        return null;
    }
    public static void main(String[] args) {
//        ArrayList<Integer> inParam = new ArrayList<>();
//        ArrayList<Integer> returnValue = justDoIt(inParam);

//        ArrayList<Integer> inParam = new ArrayList<>(); //OK
//        List<Integer> returnValue = justDoIt(inParam);  //OK

//        ArrayList<Integer> inParam = new ArrayList<>();
//        List<Number> returnValue = justDoIt(inParam);

//        List<Number> inParam = new ArrayList<>();
//        ArrayList<Integer> returnValue = justDoIt(inParam);

//        List<Number> inParam = new ArrayList<>();       //OK
//        List<Number> returnValue = justDoIt(inParam);   //OK

        List<Integer> inParam = new ArrayList<>();        //OK
        List<Integer> returnValue = justDoIt(inParam);    //OK
    }
}
