package p3_testing;

/**
 * Sample of JUnit usage...
 * to see how to use Idea for testing - read/look at:
 *   https://www.jetbrains.com/help/idea/testing.html
 *   https://www.jetbrains.com/help/idea/tutorial-test-driven-development.html
 *   https://www.youtube.com/watch?v=Bld3644bIAo
 */

public class Largest {
    /**
     * The method finds the largest array element...
     * @param intArray an input array of integers...
     * @return the largest element
     * @throws IllegalArgumentException if the input is wrong...
     */
    public static int largest(int[] intArray) throws IllegalArgumentException {
//        int index, max = Integer.MAX_VALUE; //TODO: first - start with this line...
//        int index, max = 0;
        int index, max = Integer.MIN_VALUE; //***
        if (intArray.length == 0) {
            throw new IllegalArgumentException("Empty Array");
        }
//        for( index = 0; index < intArray.length - 1; index++) { //TODO: second - start with this line...
        for( index = 0; index < intArray.length; index++) { //***
            if(intArray[index] > max){
                max = intArray[index];
            }
        }
        return max;
    }
}

