package generic.bride_method;

import java.util.ArrayList;
import java.util.Collection;

class WordList extends ArrayList<String> {
    public boolean add(String e){
        return !isBadWord(e) && super.add(e);
    }
    private boolean isBadWord(String s) {
        return s.startsWith("C#");
    }
    //TODO: note the compile error when having the following uncommented:
//    public boolean add(Object o){
//        return super.add((String) o);
//    }

    public String get(int i) {
        return super.get(i).toLowerCase();
    }
}

public class BridgeMethodTest1 {
    public static void main(String[] args) {
        WordList words = new WordList();
        words.add("Java");
        words.add("C");
        words.add("C++");
        ArrayList<String> strings = words; //it is a legal assignment: conversion to superclass...
        strings.add("C#");  // after type erasure this could invoke the raw method of the array list
                            // that can put C# into the good words list as the result...
        /*
        //TODO: see- to prevent calling the raw method ArrayLst.add(Object) compiler generates overriding it method in WordList:
        public boolean add(Object o){
            return add((String)o); //this explicit cast will delegate to the right add method that filters out bad words...
        }

        Similarly, to make dynamic method lookup work the synthetic method public Object get(int i) is generated as well,
        and it calls the first method String get(int i).
        TODO: It is impossible to have the two methods in Java language that differ in return type only:
            - String get(int i){...}
            - Object get(int i){...}
         But it is possible in bytecode language of the JVM (where the method specification include the return type).
         TODO: see synthetic methods byte-codes; View -> Show Bytecode (having cursor on the WordList class)
        */
        printList(strings);
//        printCollection(strings);
    }

    //TODO: BTW - how to print in a line (instead of a column) having words separated by ', ' except for the last word?
    private static <E> void printList(ArrayList<E> list){
        for (E e : list)
            System.out.println(e);
    }
}
