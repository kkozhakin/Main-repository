package lambdas;

import java.lang.reflect.Field;
import java.util.Arrays;

interface MyFunc {
    int func(int n);
}

public class VariablesCaptureDemo {

    private static int STATIC_VAR = 0;
    private int instanceVar = 1;

    private VariablesCaptureDemo(int v){
        this.instanceVar = v;
    }

    private Object test (double m) {
        System.out.println("m = " + m);
        long num = 10; //local variable
        // m = 5; // illegal use - m cannot be modified...
        MyFunc myLambda = (n) -> {
            // num++; // illegal use - num cannot be modified...
            STATIC_VAR = 1; // it's ok!
            instanceVar = 0; // it's ok!
            return (int)(num  + (long) (m + n + instanceVar + STATIC_VAR));
        };
        // num = 9; // illegal use - num cannot be modified...
        System.out.println("result = " + myLambda.func((int)m));
        return myLambda;
    }

    public static void main(String[] args) {
        VariablesCaptureDemo instance = new VariablesCaptureDemo(1);
        Object object = instance.test((int)(Math.random() * 100));
        Class myLambdaClass = object.getClass();
        // TODO: note that new myLambdaClass is created dynamically at each run (inner class is loaded at each run)...
//        Class anotherClass =  new VariablesCaptureDemo(2).test((int)(Math.random() * 100));
//        System.out.println("myLambdaClass = " + myLambdaClass);
//        System.out.println("myAnotherClass = " + anotherClass);

        System.out.println("   superclass = " + myLambdaClass.getSuperclass());
        System.out.println("   interfaces = " + Arrays.toString(myLambdaClass.getInterfaces()));
        System.out.println("   declaredMethods = " + Arrays.toString(myLambdaClass.getDeclaredMethods()));
//        System.out.println("   publicMethods = " + Arrays.toString(myLambdaClass.getMethods()));
        System.out.println("   publicMethods.length = " + myLambdaClass.getMethods().length);
//        System.out.println("   objectPublicMethods.length = " + Object.class.getMethods().length);

        System.out.println("   declaredFields = " + Arrays.toString(myLambdaClass.getDeclaredFields()));
        System.out.println("   declaredFields.length = " + myLambdaClass.getDeclaredFields().length);
        Field[] fields = myLambdaClass.getDeclaredFields();
        // only this reference and local variables are captured (like it happens for inner classes ...):
        try {
            for (Field field : fields) {
                field.setAccessible(true);
                System.out.println("name = " + field.getName() + "; type = " + field.getType() + "; value = " + field.get(object));
            }
        } catch (Exception ex){
            System.out.println("got exception: " + ex);
        }
    }
}
