package java_assertions;

/**
 * Notes:
 * - to enable/disable assertions use VM options -ea / -da or -enableassertions / -disableassertions;
 * - assertions are disabled by default;
 */
public class AssertTest1 {
    public static void main(String[] args) {
        try {
            System.out.println("programm is started.");
            assert (args != null); //TODO: note that args-array is not null here...
            System.out.println("args.length = " + args.length);
            assert (args.length != 0);
            System.out.println("programm is finished.");
        } catch (AssertionError ae){
            System.out.println("assertion: " + ae);
        }
    }
}
