package sample_1.interface_impl;

import javax.swing.*;
import java.awt.*;
import java.util.Date;

/**
 * TODO: replacing anonymous class with lambda - next lecture...
 */
public class TalkingClock_v7 {

    public static void main(String[] args) {
        boolean beep = (args.length == 0);
//        beep = !beep; //todo: uncomment and explain...
        new Timer(1000, event -> {
            System.out.println("The time is " + new Date());
            if (beep)
                Toolkit.getDefaultToolkit().beep();
        }).start();

        JOptionPane.showMessageDialog(null, "Quit program?");
        System.exit(0);
    }
}
