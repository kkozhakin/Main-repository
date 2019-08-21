package p3_testing;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class LargestTest {

    @BeforeEach
    void setUp() {
        System.out.println("setUp()");
    }

    @AfterEach
    void tearDown() {
        System.out.println("tearDown()");
    }

    @Test
    void testEmptyArray() {
        System.out.println("1");
        Exception exception = null;
        try{
            int res = Largest.largest(new int[0]);
        } catch (Exception ex) {
            System.out.println("ex = " +ex);
            exception = ex;
        }
        assertNotNull(exception);
        assertTrue( exception instanceof IllegalArgumentException);
        assertEquals("Empty Array", exception.getMessage());
    }

    @Test
    void testNullArray() {
        System.out.println("2");
    }

    @Test
    void testMaxSample1() {
        int[] s1  = new int[]{1,2, 3, 4, 5};
        int res = Largest.largest(s1);
        System.out.println("res = " + res);
        assertTrue(5 == res);
    }
}