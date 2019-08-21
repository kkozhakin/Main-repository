package exceptions.multicatch;

import java.util.Random;

class SampleException1 extends Exception{SampleException1(String s){super(s);}}
class SampleException2 extends Exception{SampleException2(String s){super((s));}}

public class MultiCatchSample {

    private static final Random random = new Random();

    public static void main(String[] args) throws SampleException1, SampleException2 {
        int i = 0;
        while (i < 10) {
            try {
                test();
            } catch (Exception e) {
                System.out.println("i = " + i + ": exception = " + e);
            }
            i++;
        }
    }

    private static void test() throws
            SampleException1, SampleException2
            //Exception
    {
        try {
            doSomething();
        } catch (SampleException1 | SampleException2 e){
            System.out.println("got exception: " + e + "; e.getClass() = " + e.getClass());
            throw e; //TODO; to have e rethrown we need to declare all exceptions in throws clause above...
        }
    }

    private static void doSomething() throws SampleException1, SampleException2 {
        int n = random.nextInt();
        if (n % 2 == 0){
            throw new SampleException1("" + n);
        } else {
            throw new SampleException2("" + n);
        }
    }
}
