package constructor_ref;

import java.util.Arrays;

interface  MyFuncInteface<R, T>{
    R func(T t);
}

interface MyArrayCreator<T> {
    T func(int n);
}

class MyStringClass {

    private String str;

    MyStringClass(String s) {
        str = s;
    }
    MyStringClass(){
        str = "";
    }
    String getValue(){
        return str;
    }
    public String toString() {
        return getClass().getName() + "(" + str + ")";
    }
}

public class ConstructorRefDemoFactory {

    private static <R, T> R myClassFactory(MyFuncInteface<R, T> constr, T v) {
        return constr.func(v);
    }

    public static void main(String[] args) {
        MyFuncInteface<MyGenericClass<Double>, Double> myClassConstr = MyGenericClass::new;
        MyGenericClass<Double> obj = myClassFactory(myClassConstr, Math.PI);
        System.out.println(obj);

        MyFuncInteface<MyStringClass, String> anotherConstr = MyStringClass::new;
        MyStringClass obj2 = myClassFactory(anotherConstr, "Lambdas");
        System.out.println(obj2);

    // TODO: see - how arrays can be created:
        MyArrayCreator<MyClass[]> myArrayCreator = MyClass[]::new;
        MyClass[] array = myArrayCreator.func(2);
        array[0] = new MyClass(1);
        array[1] = new MyClass(2);
        System.out.println(Arrays.toString(array));
    }
}
