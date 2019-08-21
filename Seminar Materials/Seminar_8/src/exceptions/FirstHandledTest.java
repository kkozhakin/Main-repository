package exceptions;

// TODO: show incorrect text in the book Java Notes for Professionals, section 68.1 (the book is uploaded in moodle)

public class FirstHandledTest {
    public static void main(String[] args) {
        try{
            test();
        }catch (Throwable throwable){
            System.out.println("throwable = " + throwable);
        }
    }

    private static void test(){
        try{
            doSomething();
        } catch (Exception e){
            System.out.println("Exception");
//            e = new RuntimeException("ququ");
//            throw new RuntimeException(e);
        } // todo uncomment below to see the Error!
//          catch (RuntimeException re) {
//              System.out.println("RuntimeException");
//          }
    }

    private static void doSomething() throws Exception {
//        throw new RuntimeException();
        throw new Exception();
    }
}
