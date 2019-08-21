package method_ref;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class MyClass{
    private int val;

    MyClass(int v) {
        val = v;
    }
    int getVal(){
        return val;
    }
}

public class UseMethodRef {

    // TODO: note that no class implementing Comparator<T> - interface, with its' instance, is needed any more...
    private static int compareMC (MyClass a, MyClass b) {
        return a.getVal() - b.getVal();
    }

    public static void main(String[] args) {
        List<MyClass> list = new ArrayList<>();
        list.add(new MyClass(1));
        list.add(new MyClass(4));
        list.add(new MyClass(2));
        list.add(new MyClass(9));
        list.add(new MyClass(3));
        list.add(new MyClass(7));

        MyClass max = Collections.max(list, UseMethodRef::compareMC);
        System.out.println("Max value is " + max.getVal());
    }
}
