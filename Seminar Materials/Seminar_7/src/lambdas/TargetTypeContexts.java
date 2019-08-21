package lambdas;

import java.util.Random;

interface MyFunct0 {
    void somethingTBD();
}

interface MyFunct1 {
    int action(MyFunct0 funct0);
}

interface MyFunc2 extends MyFunct1 {
    default String whoIsIt(){return "MyFunc2";}
}

public class TargetTypeContexts {

    private static MyFunct1 f1 = (f) -> 0;
    private static MyFunct1 f2 = (f) -> {System.out.println(f.getClass()); return 1;};

    public static void main(String[] args) {
        MyFunct1 localF1 = f1;
        System.out.println("localF1 = " + localF1);

        localF1 = f2;
        System.out.println("localF1 = " + localF1);

        int n = 7;
        MyFunct0 localF0 = () -> System.out.println("n = " + n);

        System.out.println(localF1.action(localF0));

        Random random = new Random();
        final  int m = random.nextInt();

        MyFunct0 myFunct0 = getFunc(m);
        myMethod(myFunct0);

        myMethod(() -> {});
    }

    private static MyFunct0 getFunc(int n){
        return () -> System.out.println("n = " + n);
    }

    private static void myMethod(MyFunct0 ogogo) {
        ogogo.somethingTBD();
    }


}

