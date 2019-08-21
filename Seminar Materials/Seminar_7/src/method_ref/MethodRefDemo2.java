package method_ref;

public class MethodRefDemo2 {

    private static String stringOps(StringFunc sf, String s){
        return sf.func(s);
    }

    public static void main(String[] args) {
        String in = "Lambdas add power to Java";
        String out;

        // one variant of target context:
        MyStringOps ops = new MyStringOps();
        out = stringOps(ops::strReverse, in);
        System.out.println(out);

        // another target context of the functional interface:
        StringFunc sf = ops::strReverse;
        out = sf.func(in);
        System.out.println(out);
    }
}
