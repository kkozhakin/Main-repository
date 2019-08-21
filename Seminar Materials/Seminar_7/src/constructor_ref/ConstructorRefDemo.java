package constructor_ref;

interface MyFunc {
    MyClass func(int n);
}

class MyClass {
    private int value;

    MyClass(int v) {
        value = v;
    }
    MyClass() {
        value = 0;
    }
    int getValue() {
        return value;
    }
    public String toString(){
        return getClass().getName() + "(" + value + ")";
    }
}

public class ConstructorRefDemo {
    public static void main(String[] args) {
        MyFunc myConstructor = MyClass::new;
        MyClass myClassInstance = myConstructor.func(100);
        System.out.println(myClassInstance);
    }
}