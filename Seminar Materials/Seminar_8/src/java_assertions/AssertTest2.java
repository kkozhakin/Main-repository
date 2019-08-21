package java_assertions;

/**
 * Notes:
 * - to enable/disable assertions use VM options -ea / -da or -enableassertions / -disableassertions;
 * - assertions are disabled by default;
 * - it is possible to enable assertions per package:
 * use options -ea:assertions... (i.e. :<package_name>... )
 *
 */

public class AssertTest2 {
    public static void main(String[] args) {
        try {
            System.out.println("programm is started.");
            assert (args != null) : "Message from assert 1..." ;
            System.out.println("args.length = " + args.length);
//            assert (args.length != 0) : "Message from assert 2 ...";
//            assert (args.length != 0) : message();
//            assert (args.length != 0) : intMessage();
//            assert (args.length != 0) : voidMethod(args);
            assert (args.length != 0) : povideMessage(args);
            System.out.println("programm is finished.");
        } catch (AssertionError ae){
            System.out.println("assertion: " + ae);
        }
    }

    private static String message(){
        return "oieiei!!!";
    }

    private static int intMessage(){
        return 25;
    }
    private static Object povideMessage(String[] args){
        return args;
    }

    private static void voidMethod(String[] args){

    }
}
