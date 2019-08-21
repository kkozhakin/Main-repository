package sample_6;

//TODO: what will be printed and why?
//TODO: run as is, then try with line 12 commented out...what's up?

class OuterClass {

    private int v = 7;
    private int var = 1;

    class InnerClass {

        private int var = 2; //TODO: comment it out...

        void output1(){
            System.out.println("output1(): " + OuterClass.this.var);
            System.out.println("output1(): " + OuterClass.this.v);
        }
        void output2(){
            System.out.println("output2(): " + var); // variable is directly accessible from outer class instance
            System.out.println("output2(): " + v);
        }
        //TODO: explain the difference - this.var vs. var:
        void output3(){
            System.out.println("output3(): " + this.var); // this in inner class means exactly this...
            System.out.println("output3(): " + var); // var in inner class means any var accessible from inner class instance
            System.out.println("output3(): " + v);
        }
    }
}

public class OuterInnerVariableTest {
/*
    private int v = 17;

    class OuterClass {

        private int v = 7;
        private int var = 1;

        class InnerClass {

            private int var = 2;

            void output1(){
                System.out.println("output1(): " + OuterClass.this.var);
                System.out.println("output1(): " + OuterClass.this.v);
            }
            void output2(){
                System.out.println("output2(): " + var); // variable is directly accessible from outer class instance
                System.out.println("output2(): " + v);
            }
            void output3(){
                System.out.println("output3(): " + this.var); // this in inner class means exactly this...
                System.out.println("output3(): " + var); // var in inner class means any var accessible from inner class instance
                System.out.println("output3(): " + v);
                System.out.println(OuterInnerVariableTest.OuterClass.this.v); // = 5;
            }
        }
    }
//*/

    public static void main(String[] args) {
        OuterClass.InnerClass myInnerObject = new OuterClass().new InnerClass();
//        OuterClass.InnerClass myInnerObject = new OuterInnerVariableTest().new OuterClass().new InnerClass();
        myInnerObject.output1();
        myInnerObject.output2();
        myInnerObject.output3();
    }
}
