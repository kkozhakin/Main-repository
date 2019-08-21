package method_ref;

interface MyFunc2<T>{
    int func(T[] values, T v);
}

class MyArrayOps {
    static <T> int countMatching (T[] values, T v) {
        int count = 0;
        for (T val : values) {
            if (val == v)
                count++;
        }
        return count;
    }
}

public class MethodRefDemo_Generic {
    private static <T> int myOp (MyFunc2<T> f, T[] values, T v) {
        return f.func(values, v);
    }

    public static void main(String[] args) {
        Integer[] values = {1, 2, 3, 4, 2, 3, 4, 4, 5};
        String[] strs = {"one", "two", "three", "two"};
        int count;
        count = myOp(MyArrayOps::countMatching, values, 4);
        System.out.println("values contains " + count + " 4's");

        count = myOp(MyArrayOps::countMatching, strs, "two");
        System.out.println("strs contain " + count + " two's");
    }
}
