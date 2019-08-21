package exceptions;

/**
 * TODO: explain all the console output: why we see that order of messages in the console?
 */
public class TryCatchTest {

    public static void main(String[] args){
        Object[] myObjectArray = createObjectAreray(7);

        try {
            Object myObject = myObjectArray[3];
            System.out.println("myObject = " + myObject);
        } catch (ArrayIndexOutOfBoundsException exception){
            System.out.println("got exception: " + exception);
            exception = new ArrayIndexOutOfBoundsException("were my code is wrong?"); // todo: note: exception is not final
            printException(exception);
        }

        // TODO: note that here we use to catch two exceptions at once (multi-catch)...
        try {
            Object myObject = myObjectArray[3];
            System.out.println("myObject = " + myObject);
        } catch (NullPointerException | ArrayIndexOutOfBoundsException exception){
            System.out.println(exception);
           // exception = null; // todo: note: exception is final here...
            exception.printStackTrace();
        }
    }

    private static Object[] createObjectAreray(int length){
        System.out.println("...creating array having the length = " + length);
//        return new Object[length];
//        return null;
        return new Object[2];
    }

    private static void printException(Exception ex){
        System.out.println("" + ex); // TODO: guess - why there is a warning without ""-string (code style)?
}
}
