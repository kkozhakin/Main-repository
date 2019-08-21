package exceptions;

class SomeException extends Exception{}

public class IgnoringException {
    public static void main(String[] args) {
        try {
            showSomething();
        } catch (SomeException ignored) {

        }

        try {
            showSomething();
         //TODO: note warning about the empty catch block below (instead of above case). How eliminate the warning?
        } catch (SomeException ex){

        }
    }

    private static void showSomething() throws SomeException {}
}
