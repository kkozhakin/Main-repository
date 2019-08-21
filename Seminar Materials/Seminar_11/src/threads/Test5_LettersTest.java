package threads;

public class Test5_LettersTest extends Thread {

    final StringBuffer letter;

    Test5_LettersTest(StringBuffer letter){
        this.letter = letter;
    }


    public static void main(String[] args){
        StringBuffer sb = new StringBuffer("A");
        new Test5_LettersTest(sb).start();
        new Test5_LettersTest(sb).start();
        new Test5_LettersTest(sb).start();
    }

    public void run(){
        synchronized (letter) {
            for (int i = 1; i <= 100; ++i)
                System.out.print(letter);
            System.out.println();
            char temp = letter.charAt(0);
            ++temp;
            letter.setCharAt(0, temp);
        }
    }



//    public void run(){
//        for(int i = 1; i <= 100; ++i)
//            System.out.print(letter);
//        System.out.println();
//        char temp = letter.charAt(0);
//        ++temp;
//        letter.setCharAt(0, temp);
//    }
}
