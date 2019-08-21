interface Scavenger{}

class Bird{}

class Parrot extends Bird{}

class Vulture extends Bird implements Scavenger{}

class BirdSanctuary {
    public static void main(String args[]) {
        Bird bird = new Bird();
        Parrot parrot = new Parrot();
        Vulture vulture = new Vulture();

//         Vulture vulture2 = (Vulture)parrot;
//         Parrot parrot2 = (Parrot)bird;
         Scavenger sc = (Scavenger)vulture;
         Scavenger sc2 = (Scavenger)bird;
    }
}

//class Machine {
//    void start() throws Exception {
//        System.out.println("start machine");
//    }
//}
