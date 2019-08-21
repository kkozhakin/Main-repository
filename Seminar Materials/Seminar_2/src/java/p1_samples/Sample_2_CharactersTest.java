package p1_samples;

public class Sample_2_CharactersTest {
    public static void main(String[] args){
        char a = '[';
        char b = ']';

        char c = '\u005B';
        char d = '\u005D';

//        char e = '\u005C'; // todo: uncomment and explain: what's happening?
        char f = '\u005B' + 1;

        System.out.println(a);
        System.out.println(b);
        System.out.println(c);
        System.out.println(d);
        System.out.println(f);
        System.out.println("--------------------------------------------------------");

        for (int i = 91; i < 128; i++){
            System.out.println((char)i);
        }

        System.out.println("--------------------------------------------------------");
        char rus_a = 'а';
        System.out.println((int)rus_a); //1072 = 1024 + 48 => 0x430 ?
        System.out.println(0x430);
        System.out.println('\u0430');
        System.out.println("--------------------------------------------------------");

        for (int i = 1072; i < 1104; i++){
            System.out.println((char)i);
        }
    }
}
