package exceptions.rethrow;

class OpenException extends Exception {}

class CloseException extends Exception {}

//  TODO: note - that is too verbose...
public class PreciseRethrow {

    public static void main(String args[]) throws OpenException, CloseException {
        boolean flag = true;
        try {
            if (flag){
                throw new OpenException();
            }
            else {
                throw new CloseException();
            }
        } catch(OpenException oe) {
            System.out.println(oe.getMessage());
            throw oe;
        } catch (CloseException ce) {
            System.out.println(ce.getMessage());
            throw ce;
        }
    }
}

// TODO: note - that's less verbose, but client applications no longer have the benefit of easily dealing with
// TODO: the specific CloseException or OpenException when they are thrown.

class RethrowVariant {
    public static void main(String args[]) throws Exception { // a client cannot see Exception variants...
        boolean flag = true;
        try {
            if (flag){
                throw new OpenException();
            }
            else {
                throw new CloseException();
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            throw e;
        }
    }
}

//TODO: note - that was impossible prior Java 7:
class RethrowVariant1 {
    public static void main(String args[]) throws OpenException, CloseException {
        boolean flag = true;
        try {
            if (flag){
                throw new OpenException();
            }
            else {
                throw new CloseException();
            }
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            throw e;
        }
    }
}

class RethrowVariant2 {
    public static void main(String args[])
            throws
                OpenException, CloseException
                ,
                Exception
    {
        boolean flag = true;
        try {
            if (flag){
                throw new OpenException();
            }
            else {
                throw new CloseException();
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            e = new OpenException(); // reassigning e - is valid here...
            //TODO: but we need to declare Exception in throws above...i.e. do like before java 7...
             throw e;
        }
    }
}