package collections;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/*
TODO: It is tricky to remove items from a list while within a loop:
      this is due to the fact that the index and length of the list gets changed.

TODO: show from the book "Java Notes for Professionals": chapter 45, section 45.1 ...
//*/
public class RemovingFromList {

    public static void main(String[] args) {

        // 1. TODO: show - Incorrect:
        System.out.println("\r\n1. In for-loop:");
        List<String> fruits = createList();
        for (int i = 0; i < fruits.size(); i++) {
            System.out.println ("i = " + i + ": " +fruits.get(i));
            if ("Apple".equals(fruits.get(i))) {
                fruits.remove(i); //TODO: read what the compiler is warning about...
            }
        }
        System.out.println("Where is Banana ??? We were removing Apple...");
//        Banana is skipped because it moves to index 0 once Apple is
//        deleted, but at the same time i gets incremented to 1.
// ... but this is ok:
        System.out.println("fruits: " + fruits);

        // 2. TODO: show - Incorrect:
        System.out.println("\r\n2. In for-each loop:");
        fruits = createList();
        try {
            for (String fruit : fruits) {
                System.out.println(fruit);
                if ("Apple".equals(fruit)) {
                    fruits.remove(fruit);
                }
            }
        } catch (Exception e){
            System.out.println(" got exception: " + e);
            //e.printStackTrace();
        }
        System.out.println("fruits: " + fruits);

        // 3. TODO: show - Correct:
        System.out.println("\r\n3. In iterator loop:");
        fruits = createList();
        Iterator<String> fruitIterator = fruits.iterator();
        while(fruitIterator.hasNext()) {
            String fruit = fruitIterator.next();
            System.out.println(fruit);
            if ("Apple".equals(fruit)) {
                fruitIterator.remove();
            }
        }
        System.out.println("fruits: " + fruits);


    // 4. TODO: show - non structural modification of the list (no add-remove):
        System.out.println("\r\n4. In iterator loop: no structural change in the list:");
        fruits = createList();
        fruitIterator = fruits.iterator();
        fruits.set(0, "Watermelon"); // "арбуз" - it does not modify the structure of the list, just changes one value
        while(fruitIterator.hasNext()) {
            System.out.println(fruitIterator.next());
        }
        System.out.println("fruits: " + fruits);

    // 5. TODO: show - structural modification of the list (add):
        System.out.println("\r\n4. In iterator loop: structural change in the list:");
        fruits = createList();
        fruitIterator = fruits.iterator();
        try {
            fruits.add("Watermelon"); // "арбуз" - it DOES modify the structure of the list, just changes one value
            while (fruitIterator.hasNext()) {
                System.out.println(fruitIterator.next());
            }
        } catch (Exception e){
            System.out.println(" got exception: " + e);
            //e.printStackTrace();
        }
        System.out.println("fruits: " + fruits);
    }


    private static List<String> createList(){
        List<String> fruits = new ArrayList<>();
        fruits.add("Apple");
        fruits.add("Banana");
        fruits.add("Orange");
        return fruits;
    }

}

