package lambdas;

class EmptyArrayException extends Exception {
    EmptyArrayException() { super("Array is Empty"); }
}

interface DoubleNumericArrayFunc {
    double func(double[] array) throws EmptyArrayException; //must be present...
}

public class LambdaExceptionDemo {
    public static void main(String[] args) throws EmptyArrayException {
//        double[] values = {1.0, 2.0, 3.0, 4.0, 5.0};
        double[] values = {};
        DoubleNumericArrayFunc average = (a) -> {
            double sum = 0;
            if (a.length == 0)
                throw new EmptyArrayException();
            for (double anA : a) sum += anA;
            return sum / a.length;
        };
//        System.out.println("The average = " + average.func(new double[0]));
        System.out.println("The average = " + average.func(values));
    }
}
