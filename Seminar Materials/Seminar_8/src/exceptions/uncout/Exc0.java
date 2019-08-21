package exceptions.uncout;

// TODO: note that stack trace is provided...

public class Exc0 {
//    static String s = null;
    String s;
    public static void main(String[] args) throws RuntimeException {
//        String s = null;
        System.out.println(new Exc0().s);
        int d = 0;
        int a = 42 / d;
        System.out.println(getNum());
    }

    static int getNum(){
        int b = 0;
        return ++b;
    }
}


class Exc1 {
    public static void main(String[] args) {
        subroutine();
    }

    private static void subroutine(){
//        int d = 0;
        int a = 42 / 0;
    }
}

class EJava {
    public static void main(String[] args) {
        guru();
    }
    static void guru (){
        throw new StackOverflowError();
    }
}

