package seminar_3.sample_10;

import java.util.GregorianCalendar;

/**
 * TODO: when and which instances of GregorianCalendar become eligible for GC?
 */
public class GCDemo {

    public static void main(String [] args) {

        GregorianCalendar christmas, newyears;

        christmas = new GregorianCalendar(2018,12,25);
        newyears = new GregorianCalendar(2019,1,1);

        christmas = newyears;
        GregorianCalendar d = christmas;
        christmas = null;
    }
 }

