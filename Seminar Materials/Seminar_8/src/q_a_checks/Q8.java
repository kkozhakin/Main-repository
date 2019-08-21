package q_a_checks;

public class Q8 {
}

class EJava {
    void method(){
        try {
            guru();
            return;
        } finally {
//            System.out.println("finally 1");
            System.err.println("finally 1");
        }
    }
    void guru(){
//        System.out.println("guru");
        System.err.println("guru");
        throw new StackOverflowError();
    }

    public static void main(String[] args) {
        EJava var = new EJava();
        var.method();
    }
}
