package generic.wildcards;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;

public class WildcardsSamples {
    public static void main(String[] args) {
        unboundedWildcardSample();
        upperBoundedWildcardSample();
        lowerBoundedWildcardSample();
    }

    private static void unboundedWildcardSample(){
        // TODO: see Unbound Wildcards usage (we cannot modify/populate it):
        List<?> stuff = new ArrayList<>();
//        stuff.add("abc");
//        stuff.add(new Object());
//        stuff.add(3);
        int numElements = stuff.size(); // = 0
        System.out.println(stuff + ": " + numElements);
        // TODO: but we can use it in methods parameters as below:
        List<Integer> integerList = new ArrayList<>(Arrays.asList(1,2,3,4,5));
        List<Double> doubleList = new LinkedList<>(Arrays.asList(1.0, 2.0, 3.0));
        printList(integerList);
        printList(doubleList);
    }

    //TODO: note unbound wildcard in the parameter type:
    private static void printList(List<?> list) {
        System.out.println(list);
    }

    private static void upperBoundedWildcardSample(){
//        List<? extends Number> numbers = new ArrayList<>();
        //TODO: note - We cannot modify it...
//        numbers.add(1);
//        numbers.add(Math.PI);
        //TODO:  but we can extract numbers from it when it is prepared and passed as parameter:
        List<Integer> integerList = new ArrayList<>(Arrays.asList(1,2,3,4,5));
        List<Double> doubleList = new LinkedList<>(Arrays.asList(1.0, 2.0, 3.0));
        printListSum(integerList);
        printListSum(doubleList);
    }

    private static void printListSum(List<? extends Number> numbers){
        double result = 0.0;
        for (Number n : numbers){ //TODO: note that we & compiler know that n is a Number...
            result += n.doubleValue();
        }
        System.out.println("sum = " + result);
    }

    private static void lowerBoundedWildcardSample(){
        List<Integer> integerList = new ArrayList<>();
//        List<Double> doubleList = new ArrayList<>();
        List<Number> numberList = new ArrayList<>();
        List<Object> objectList = new ArrayList<>();
        List<Serializable> serializableList = new ArrayList<>(); // Number is Serializable

        //TODO: see class Integer extends Number implements Comparable<Integer>...
        List<Comparable> comparableList = new ArrayList<>();
        List<Comparable<Integer>> comparableIntegers = new ArrayList<>();

        populateList(4, integerList);
//        populateList(5, doubleList); //TODO: note -  Double is not an ancestor of Integer
        populateList(5, numberList);
        populateList(6, objectList);
        populateList(7, serializableList); //TODO: note that Number implements Serializable
        populateList(8, comparableList);
        populateList(9, comparableIntegers);


        printList(integerList);
        printList(numberList);
        printList(objectList);
        printList(serializableList);
        printList(comparableList);
        printList(comparableIntegers);
    }

    private static void populateList(int max, List<? super Integer> resultList){
        for (int i = 0; i < max; i++)
            resultList.add(i);
    }
}
