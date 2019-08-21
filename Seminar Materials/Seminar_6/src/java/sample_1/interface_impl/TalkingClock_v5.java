package sample_1.interface_impl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Date;

/**
 *  Now we use local inner class (see named class TimePrinter).
 *  TODO: comment/uncomment beep = ! beep below...
 */

public class TalkingClock_v5 {

    public void start(int interval, boolean beep) { // now inner class inside the method:
        //todo: see that there are no access specifiers before the class:
        class TimePrinter implements ActionListener {
            public void actionPerformed(ActionEvent event) {
                System.out.println("At the tone, the time is " + new Date());
                if (beep)
                    Toolkit.getDefaultToolkit().beep();
//                beep = !beep; // todo: what's happening? now it must be final (JDK8) or effectively final (JDK9)...Why?
            }
        }
        ActionListener listener = new TimePrinter();
        Timer t = new Timer(interval, listener);
        t.start();
    }

    public static void main(String[] args) {
        new TalkingClock_v5().start(1000, true);
        JOptionPane.showMessageDialog(null, "Quit program?");
        System.exit(0);
    }
}
