package method_ref;

interface StringFunc {
    String func(String s);
}

class MyStringOps {
    // TODO: note that code is compatible with StringFunc functional interface...
    static String strReverse_static(String str) {
        String res = "";
        for (int i = str.length() - 1; i >= 0; i--) {
            res += str.charAt(i);
        }
        return res;
    }
    String strReverse(String str) {
        String res = "";
        for (int i = str.length() - 1; i >= 0; i--) {
            res += str.charAt(i);
        }
        return res;
    }


}
