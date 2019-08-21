package generic.variables;

import java.lang.reflect.Field;

public class Test {

    public static void main(String[] args) {

        Variable<String> stringVariable = new Variable<>("Hello");
        Variable<Integer> integerVariable = new Variable<>(555);
        //TODO: explain - why the followin does not compile:
//        Variable<Number> integerVariable = new Variable<>(new Integer(500));

        System.out.println("stringVariable.getValue() = " + stringVariable.getValue());
//  Integer iobj = integerVariable.getValue();
        System.out.println("integerVariable.getValue() = " + integerVariable.getValue());

        System.out.println("stringVariable.getClass() = " + stringVariable.getClass());
        System.out.println("integerVariable.getClass().getName() = " + integerVariable.getClass().getName());

        testCastsInByteCode(); //TODO: show decompiles code...

        //TODO: show types fo the value fields in classes of the variables:
        try {
            Field fValue1 = stringVariable.getClass().getDeclaredField("value");
            Class valueClass1 = fValue1.getType();
            System.out.println("valueClass for stringVariable = " + valueClass1);

            Field fValue2 = integerVariable.getClass().getDeclaredField("value");
            Class valueClass2 = fValue2.getType();
            System.out.println("valueClass for integerVariable = " + valueClass2);

        } catch (NoSuchFieldException nsfe) {
            System.out.print("no field \"value\" in the class... ");
        }
    }

    //TODO: File->Open->...Test.class (in decompiler window) and see the cast for getValue() result...
    public static void testCastsInByteCode(){
        Variable<String> stringVariable = new Variable<>("Hello");
        String s = stringVariable.getValue();
        System.out.println("s = " + s);
        Variable<Integer> integerVariable = new Variable<>(777);
        Integer i = integerVariable.getValue();
        System.out.println("i = " + i);
    }
}
