package sample_1;

//TODO: execute main()-method step by step (F7): see what's going on and when...
//TODO: uncomment commented strings and explain the difference...

interface MyInterface {

    static final int VALUE = 7;

    public static int initNumber(){
        System.out.println("initNumber() invoked.");
        return helper();
    }

    //private
    static int helper(){
        return VALUE;
    }

    int INT_NUMBER = initNumber();

    public default int getIntNumber(){
        return intGetter();
    }

    //private //TODO: private methods - in JDK 9(+). By the way - last week JDK 11 was published as Long Term Support.
    //static
    default
    int intGetter(){
        return  INT_NUMBER;
    }
}

class MyObject implements MyInterface {
    static {
        System.out.println("MyObject: static initializer");
    }

    public static void main(String[] args) {
        System.out.println("MyInterface.INT_NUMBER = " + MyInterface.INT_NUMBER );
        System.out.println("MyInterface.INT_NUMBER * 2 = " + MyInterface.INT_NUMBER * 2);
    }
}