package lambdas;

interface MyNumber {
    double getValue();
//    double ququ();
}

public class LambdaDemo1 {
    public static void main(String[] args) {
        // reference to functional interface:
        MyNumber myNum;
        Object myObj;

        myNum = () -> 123.45;
        myObj = myNum;

        System.out.println("fixed value is: " + myNum.getValue());

        myNum = () -> Math.random() * 100;
        System.out.println("random value * 100 is: " + myNum.getValue());
        System.out.println("random value * 100 is: " + myNum.getValue());

        // todo: explain - were is the error here and why:
//        myNum = () -> "123.45"; //compile error...

        System.out.println("myNum.getClass() = " + myNum.getClass());

        // todo: what is the difference comparing with lambda above?
        // todo: note that class file is NOT generated for the lambda-expression, but the class for it is present...

        myNum = new MyNumber() {
            @Override
            public double getValue() {
                return Math.random() * 100;
            }
        };
        System.out.println("random value * 100 is: " + myNum.getValue());
        System.out.println("random value * 100 is: " + myNum.getValue());

        System.out.println("myNum.getClass() = " + myNum.getClass());
    }
}
