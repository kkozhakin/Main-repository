package method_ref;


public class MethodRefDemo1 {

    private static String stringOps(StringFunc sf, String s){
        return sf.func(s);
    }

    public static void main(String[] args) {
        String in = "Lambdas add power to Java";
        String out;

        // one variant of target context:
        out = stringOps( MyStringOps::strReverse_static, in);
        System.out.println(out);

        // another target context of the functional interface:
        StringFunc sf = MyStringOps::strReverse_static;
        out = sf.func(in);
        System.out.println(out);
    }
}
