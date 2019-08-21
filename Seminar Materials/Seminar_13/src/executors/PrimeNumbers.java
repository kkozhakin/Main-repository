package executors;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;

import static executors.TaskGroupSample_Primes.LONG_INTERVAL;
import static executors.TaskGroupSample_Primes.LONG_M;

public class PrimeNumbers {

    public static final BigInteger ZERO = BigInteger.valueOf(0);
    public static final BigInteger ONE = BigInteger.valueOf(1);
    public static final BigInteger TWO = BigInteger.valueOf(2);

    public static boolean isPrime(BigInteger number) {
        for (BigInteger i = TWO;  square(i).subtract(number).signum() < 0; i = i.add(ONE)) {
            if (number.mod(i).signum() == 0) {
                return false;
            }
        }
        return true;
    }
    private static BigInteger square(BigInteger n) {
        return n.multiply(n);
    }

    public static boolean isPrime(long number) {
        for (long i = 2L; i < Math.sqrt(number) ; i = i + 1) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    }

    public static List<BigInteger> listPrimesInInterval(BigInteger start, BigInteger length){
        List<BigInteger> result = new ArrayList<>();
        for (BigInteger i = start; i.subtract(length.add(start)).signum() < 0; i = i.add(ONE)){
            if (isPrime(i))
                result.add(i);
        }
        return result;
    }

    public static List<Long> listPrimesInInterval(long start, long length){
        List<Long> result = new ArrayList<>();
        for (long i = start; i < (start + length); i = i + 1){
            if (isPrime(i))
                result.add(i);
        }
        return result;
    }

    public static void main(String[] args) {
//        testBigIntegers();
        testLongIntegers();
    }

    private static void testBigIntegers() {
        for (int n = 0; n < 10; n++) {
            BigInteger start = TaskGroupSample_Primes.M.add(TaskGroupSample_Primes.INTERVAL.multiply(BigInteger.valueOf(n)));
            List<BigInteger> res = PrimeNumbers.listPrimesInInterval(start, TaskGroupSample_Primes.INTERVAL);
            System.out.println(res);
        }
    }

    private static void testLongIntegers() {
        for (int n = 0; n < 10; n++) {
            long start = LONG_M + n * LONG_INTERVAL;
            List<Long> res = PrimeNumbers.listPrimesInInterval(start, LONG_INTERVAL);
            System.out.println(res);
        }
    }

}
