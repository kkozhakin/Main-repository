package lambdas;

interface StringFunc {
    String func(String s);
}

public class LambdaAsArgumentDemo {

    private static String stringOp (StringFunc sf, String str) {
        return sf.func(str);
    }

    public static void main(String[] args) {
        String in = "Lambdas add power to Java";
        String out;

        out = stringOp(
                (str) -> {
                    String res = "";
                    for (int i = 0; i < str.length(); i++) {
                        if (str.charAt(i) != ' ')
                            res += str.charAt(i);
                    }
                    return res;
                },
              in
        );
        System.out.println(out);

        System.out.println (stringOp ((str) -> str.toUpperCase(), "my sample string"));

        out = stringOp(String::toUpperCase, in);
//        out = stringOp(String::toUpperCase, in);
        System.out.println(out);
    }
}
