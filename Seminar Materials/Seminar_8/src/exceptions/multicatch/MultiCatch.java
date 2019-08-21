package exceptions.multicatch;

import java.util.Arrays;

public class MultiCatch {
    public static void main(String[] args) {
        int a = 10, b = 0;
        int values[] = {1, 2, 3};
        System.out.println(Arrays.toString(values));

        try {
// todo: comment & uncomment below:
//            int result = a / b; // generate ArithmeticException
            values[10] = 7; // generate ArrayIndexOutOfBoundsException
        } catch ( ArithmeticException | ArrayIndexOutOfBoundsException e ) {
            System.out.println("Exception caught: " + e);
        }
        System.out.println("Life is good...");

        try {
//            int result = a / b; // generate ArithmeticException
            values[9] = 7; // generate ArrayIndexOutOfBoundsException
        } catch (ArithmeticException ae){
            System.out.println("ArithmeticException caught: " + ae);
        } catch (ArrayIndexOutOfBoundsException aie){
            System.out.println("Exception caught: " + aie);
        }
    }
}

