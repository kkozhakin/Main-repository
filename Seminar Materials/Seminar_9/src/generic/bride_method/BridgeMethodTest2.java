package generic.bride_method;

import java.lang.reflect.Method;

class Person{}
class Manager extends Person{}

class Room<T>{
    private T owner;
    void setOwner(T person) {
        owner = person;
    }
    T getOwner() {
        return owner;
    }
}

class Office extends Room<Person>{
    void setOwner(Person person) {
        if ( !(person instanceof Manager) )
            throw new IllegalArgumentException ("to have an office a person must be a manager !");
        else
            super.setOwner(person);
    }
}

/*
TODO: see the additional synthetic method setOwner(Object) in Office.class
- Idea decompiler does not show it...
- It can be seen in Bytecode of the Office class: enable Bytecode viewer plugin and see View-> Show bytecode...
 */

public class BridgeMethodTest2 {
    public static void main(String[] args) {
        Method[] roomMethods = Room.class.getDeclaredMethods();
        System.out.println("Room methods:");
        printMethods(roomMethods);
        System.out.println();

        Method[] officeMethods = Office.class.getDeclaredMethods();
        System.out.println("Office methods:");
        printMethods(officeMethods);
        System.out.println();

        test();
    }

//    @SuppressWarnings("unchecked")
    private static void test(){
        Room<Person> room = createOffice(); //TODO: note: it's ok - an office is a room;
//        Room room = createOffice(); //TODO: note: it's ok - an office is a room;
        System.out.println("room: " + room);
        room.setOwner( new Manager()); //TODO: note: here we expect to call the <Office>.setOwner()-method (by polymorphism)!
        System.out.print("owner = " + room.getOwner());
    }

//    private static void test(){
//        Office room = createOffice();
//        System.out.println("room: " + room);
//        room.setOwner( new Manager());
//    }


    private static Office createOffice(){
        Office office = new Office();
        System.out.println("office; " + office);
        return office;
    }

    private static void printMethods(Method[] methods) {
        for (Method m : methods) {
            System.out.println(m + "; isSynthetic() = " + m.isSynthetic());
        }
    }
}
