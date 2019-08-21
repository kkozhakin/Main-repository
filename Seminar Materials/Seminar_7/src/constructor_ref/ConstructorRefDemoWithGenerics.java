package constructor_ref;

interface MyFuncGeneric<T>{
    MyGenericClass<T> func(T n);
}

class MyGenericClass<T> {

    private T value;

    MyGenericClass(T v){
        value = v;
    }
    MyGenericClass(){
        value = null;
    }
    T getValue() {return value;}

    public String toString(){
        return getClass().getName() + "(" + value.toString() + ")";
    }
}

public class ConstructorRefDemoWithGenerics {
    public static void main(String[] args) {
        MyFuncGeneric<Integer> mc = MyGenericClass::new;
        MyGenericClass<Integer> obj = mc.func(7);
        System.out.println(obj);
    }
}
