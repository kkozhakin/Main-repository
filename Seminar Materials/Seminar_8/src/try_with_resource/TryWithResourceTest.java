package try_with_resource;

// try-with-resource was introduced in JDK 7.
// TODO: see chapter 68.2 in Java Notes for Professionals book...

import java.util.Random;
import java.util.Scanner;

class MyNaughtyResource implements AutoCloseable{

//    private static final Random random = new Random();

    @Override
    public void close() throws MyResourceCloseException {
        int n = readCommand(); //random.nextInt(4);
        if (n == 3)
            throw new MyResourceCloseException(this);
        System.out.println("You might be surprised, but now my resource " + this + " is closed...");
    }
    void use() throws MyResourceUseException{
        int n = readCommand(); //random.nextInt(4);
        if (n == 2)
            throw new MyResourceUseException(this);
        System.out.println("You might be surprised, but now my resource " + this + " is used...");
    }

    static MyNaughtyResource create() throws MyResourceCreateException {
        int n = readCommand(); //random.nextInt(4);
        if (n == 1)
            throw new MyResourceCreateException();
        MyNaughtyResource res = new MyNaughtyResource();
        System.out.println("You might be surprised, but now my resource " + res + " is created...");
        return res;
    }

    private  static int readCommand(){
        Scanner input = new Scanner(System.in);
        System.out.println("Input int number (0 => ok; 1 => cannot create; 2 => cannot use; 3 => cannot close): ");
        int n = input.nextInt();
        return n % 4;
    }
}

class MyResource extends MyNaughtyResource {

    /*
    A close() method should dispose of the resource in an appropriate fashion.
    The specification states that it should be safe to call the method on a resource that has already been disposed of.
    In addition, classes that implement AutoCloseable are strongly encouraged to declare the close() method to throw
    a more specific exception than Exception, or no exception at all.
    */
    @Override
    public void close(){
        System.out.println("You might be surprised, but now my resource " + this + " is closed...");
    }

    void use() {
        System.out.println("You might be surprised, but now my resource " + this + " is used...");
    }

    static MyResource create(){
        MyResource res =  new MyResource();
        System.out.println("You might be surprised, but now my resource " + res + " is created...");
        return res;
    }
}


class MyResourceCreateException extends Exception{
    MyResourceCreateException() {super();}
}
class MyResourceUseException extends Exception{
    MyResourceUseException(MyNaughtyResource res){super(res.toString());}
}
class MyResourceCloseException extends Exception{
    MyResourceCloseException(MyNaughtyResource res){super(res.toString());}
}

/*
TODO: There are a couple of things to note though (see "Java Notes for Professionals" pages 390-391):
    The resource variable is out of scope in the catch and finally blocks.
    The resource cleanup will happen before the statement tries to match the catch block.
    If the automatic resource cleanup threw an exception, then that could be caught in one of the catch blocks.
*/
public class TryWithResourceTest {

    public static void main(String[] args) {
        test1();
        test2();
        test3();
    }

    private static void test1(){
        System.out.println("1: Start");
        try (MyResource resource = MyResource.create()) {
            resource.use();
        }
        System.out.println("1: Finish");
    }

    private static void test2(){
        System.out.println("2: Start");
        try (MyNaughtyResource resource = MyNaughtyResource.create()) {
            resource.use();
        } catch (MyResourceCreateException createException){
            System.out.println("cannot create: " + createException);
        } catch (MyResourceUseException useException){
            System.out.println("cannot use: " + useException);
        } catch (MyResourceCloseException closeException) {
            System.out.println("cannot close: " + closeException);
        }
        System.out.println("2: Finish");
    }

    private static void test3(){
        System.out.println("3: Start");
        try (MyNaughtyResource resource = MyNaughtyResource.create()) {
            resource.use();
        } catch (MyResourceCreateException | MyResourceUseException | MyResourceCloseException ex){
            System.out.println("" + ex);
        }
        System.out.println("3: Finish");
    }
}
