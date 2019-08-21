package seminar_4.sample_4;

import seminar_4.sample_4.base.TestBaseClass;

/**
 * TODO: read code and explain - why we cannot uncomment lines with ???
 */
public class ProtectedTest extends TestBaseClass {

    public ProtectedTest(){
        createObject(); // ok
    }

    public static void main(String[] args){

        TestBaseClass tb1 = new TestBaseClass();
//        tb1.createObject(); // compile error

        tb1 = new ProtectedTest();
//        tb1.createObject();  //???

        new ProtectedTest().createObject(); //ok

        ProtectedTest tb2 = new ProtectedTest();
        tb2.createObject(); //ok

        TestBaseClass tb3 = new ProtectedTest();
//        tb3.createObject(); // ???
    }

    //TODO - think - how protected member of the base class is accessed by reference
    void someMethod(){
        createObject(); //ok
        this.createObject(); //ok
        super.createObject(); //ok

        TestBaseClass tbc = new ProtectedTest();
//        tbc.createObject();

        ProtectedTest pt = (ProtectedTest)tbc;
        pt.createObject(); //ok
    }
}
