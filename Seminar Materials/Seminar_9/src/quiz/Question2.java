package quiz;

import java.util.ArrayList;

class Fruit {}
class Apple extends Fruit{}
class Orange extends Fruit{}

public class Question2 {
    public static void main(String[] args) {
        ArrayList<Apple> aList = new ArrayList<>();
        aList.add(new Apple());

//        ArrayList bList = aList;
//        ArrayList<Orange> oList = bList; //bList is just unneeded variable...

        ArrayList<Orange> oList = (ArrayList) aList; //Unchecked assignment WARNING

        oList.add(new Orange());
        System.out.println(oList);
    }
}
