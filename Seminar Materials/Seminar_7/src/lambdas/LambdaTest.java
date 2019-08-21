package lambdas;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

interface MyFunction{
    int perform(int n);
}

public class LambdaTest {
    private static int staticIntValue = 5;
    private int instanceInteValue = 7;

    public static void main(String[] args) {
        Object o = new LambdaTest().enclosingTestMethod((args.length == 0)? 33 : 55);
        System.out.println("o = " + o);
        Class c = o.getClass();
//        System.out.println("o.getClass() = " + o.getClass());
        enums.ReflectionTest.printClassInfo(c);
        printLambdaFieldValues(o);
    }

    private Object enclosingTestMethod (long param) {
        System.out.println("param = " + param);
        long num = 10; // local variable cannot be modified...
//        param = 11; // parameter cannot be modified...
//        num++;
        MyFunction myLambda = (n) -> {
            staticIntValue = 6; // ok
            instanceInteValue = 8; // ok
            return (int)(num + param + instanceInteValue + staticIntValue);
        };
        System.out.println("result = " + myLambda.perform((int)param));
        return myLambda;
    }

    static void printLambdaFieldValues(Object o){
        Field[] fields = o.getClass().getDeclaredFields();
        System.out.println("fields:");
        for (Field f : fields) {
            Class type = f.getType();
            String name = f.getName();
            System.out.print(" ");
            String modifiers = Modifier.toString(f.getModifiers());
            if (modifiers.length() > 0)
                System.out.print(modifiers + " ");
            System.out.println(type.getName() + " " + name + ";");
            try {
                f.setAccessible(true);
                Object value = f.get(o);
                System.out.println(" value = " + value);
            } catch (Exception ex){
                System.out.println("Cannot get value of " + f);
            }
        }

    }

}
