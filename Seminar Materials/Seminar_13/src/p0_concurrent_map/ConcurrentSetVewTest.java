package p0_concurrent_map;

import java.util.HashMap;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;

/**
 *  1. Получить Set вообще без использования ConcurrentHashMap
 *  2. Have ConcurrentHashMap created and populated.
 *  3. Get keySet from map; add/remove elements to/from the keySet and observe the map;
 *  4. Use keySet with default method for the same purpose...
 */
public class ConcurrentSetVewTest {
    public static void main(String[] args) {
        // Getting ConcurrentSet without having an explicit map instance...
        Set<String> stringSet = ConcurrentHashMap.newKeySet();
        stringSet.add("s1");
        stringSet.add("s2");
        stringSet.add("s3");
        stringSet.add("s4");
        System.out.println("stringSet = " + stringSet);
        System.out.println(stringSet.getClass());

        System.out.println();
        testKeySet(new ConcurrentHashMap<>());
        System.out.println();
        testKeySet(new HashMap<>());
        System.out.println();

        //TODO: note -  we can add with default:
        ConcurrentHashMap<String, Long> map = new ConcurrentHashMap<>();
        Set<String> set = map.keySet(2018L);
        System.out.println("set = " + set);
        System.out.println("map = " + map);
        set.add("ogogo");
        System.out.println("set = " + set);
        System.out.println("map = " + map);

    }

    private static void testKeySet(Map<String, Long> map){
        System.out.println(map.getClass());

        for (int i = 0; i < 4; i++){
            map.put("String_" + i, (long)i);
        }
        System.out.println("map = " + map);
        Set<String> stringSet1 = map.keySet();
        System.out.println("stringSet1 = " + stringSet1);
        System.out.println(stringSet1.getClass());


        //TODO: remove is ok...
        stringSet1.remove("String_0");
        System.out.println("stringSet1 = " + stringSet1);
        System.out.println("map = " + map);

        try{
            //TODO: note when add is prohibited (unsupported operation...)
            stringSet1.add("ogogo");
            System.out.println("stringSet1 = " + stringSet1);
            System.out.println("map = " + map);
        } catch (RuntimeException re){
            System.out.println("got exception: " + re);
        }
    }

}
