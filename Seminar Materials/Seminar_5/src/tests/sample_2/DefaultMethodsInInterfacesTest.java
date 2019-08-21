package sample_2;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;


class DefaultMethodsInInterfacesTest {
    private MyImplementor implementor;

    @BeforeEach
    void setUp() {
        System.out.println("setUp()");
        implementor = new MyImplementor();
    }

    @AfterEach
    void tearDown() {
        System.out.println("tearDown()");
        implementor = null;
    }

    @Test
    void testDefailtMethodsBehavior1(){
        assertEquals(1, implementor.myBehavior1());
    }
    @Test
    void testDefailtMethodsBehavior2(){
        assertEquals( 2, implementor.myBehavior2());
    }

    @Test
    void tetsCircleLenth(){
        double value = 2 * Math.PI;
//        assertEquals(value, implementor.circleLength(1.0)); //TODO: explain - why assertion failed...
        assertEquals(value, implementor.circleLength(1.0), 0.001);
    }
}
