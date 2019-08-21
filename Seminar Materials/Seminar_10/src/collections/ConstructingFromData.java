package collections;

import java.util.*;

// TODO: note that starting from JDK8 it can ve done using java.util.streams (to be discussed later...)

public class ConstructingFromData {
    public static void main(String[] args) {
//        List<String> data = Arrays.asList("ab", "bc", "cd", "ab", "bc", "cd");
        List<String> data = Arrays.asList("2", "2", "3", "2", "1", "2", "3", "1", "2", "3", "0");

        // will add data as is:
        List<String> list = new ArrayList<>(data);
System.out.println(list);

        // will add data as is:
        List<String> list1 = new LinkedList<>(data);
System.out.println(list1);

        // will add data keeping only unique values:
        Set<String> set1 = new HashSet<>(data);
System.out.println(set1);

        // will add data keeping unique values and sorting:
        SortedSet<String> set2 = new TreeSet<>(data);
System.out.println(set2);

        // will add data keeping only unique values and preserving the original order:
        Set<String> set3 = new LinkedHashSet<>(data);
System.out.println(set3);

//        Map<Object, Object> map = System.getProperties(); // just for info...
//System.out.println(map);
        Map<String, Object> map = createMap();
System.out.println(map);

        // this will be sorted:
        SortedMap<String, Object> sortedMap = new TreeMap<>(map);
System.out.println(sortedMap);

        HashMap<String, Object> hashMap = new HashMap<>(map);
System.out.println(hashMap);

    }

    //TODO: ptopose the initial map content so that SortedMap and HashMap (see above) will be printed differently...
    // we do it in old fashion (it may be done better using streams...)
    private static Map<String, Object> createMap(){
//        Map<String, Object> map = new LinkedHashMap<>(); //TODO: note that it preserves the order of insertions...
        Map<String, Object> map = new IdentityHashMap<>();
        for (int i = 8; i > 0; i--){
            map.put(String.valueOf(i), i * i); // TODO; boxing/unboxing -> substantial overhead...
        }
        return map;
    }
}
