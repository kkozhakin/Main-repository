package collections;

//import java.util.Iterator;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.TreeSet;

public class TreeHashLinkedHashSetSample {
    public static void main(String[] args) {
        TreeSet<String> map = new TreeSet<>(); //the order is guaranteed...
        map.add("one");
        map.add("two");
        map.add("three");
        map.add("four");
//        map.add("one"); //TODO: comment/uncomment...
        //        while (it.hasNext()) {
//            System.out.print( it.next() + " " );}
        for (Object aMap : map)
            System.out.print(aMap + " ");

System.out.println();

        HashSet<String> map1 = new HashSet<>(); //the order is NOT guaranteed...
        map1.add("one");
        map1.add("two");
        map1.add("three");
        map1.add("four");
//        map1.add("one");
        Iterator it1 = map1.iterator();
        while (it1.hasNext()) {
            System.out.print( it1.next() + " " );}

        System.out.println();

        LinkedHashSet<String> map2 = new LinkedHashSet<>();
        map2.add("one");
        map2.add("two");
        map2.add("three");
        map2.add("four");
//        map2.add("one");
        Iterator it2 = map2.iterator();
        while (it2.hasNext()) {
            System.out.print( it2.next() + " " );
        }

        System.out.println();


        TreeSet<Number> s = new TreeSet<>();
        s.add(1);
        s.add(99.9);
//        s.add(99.9);
        s.add(96.9);
        for (int i = 0; i < s.size(); i++) {
            System.out.print(s.pollFirst() + " ");
        }
    }
}
