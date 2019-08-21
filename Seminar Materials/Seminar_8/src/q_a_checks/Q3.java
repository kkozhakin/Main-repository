package q_a_checks;

public class Q3 {
    public static void main(String[] args) {
        try {
            myMethod();
        } catch (StackOverflowError err){
            for (int i = 0; i < 2; ++i){
                System.out.println(i);
            }
        }
    }
    private static void myMethod(){
        myMethod();
    }
}
