package sample_1.interface_impl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Date;

/**
 *  TODO: note - now we use [non-static] inner class, that can access outer class data fields...
 */

public class TalkingClock_v4 {

    private int interval;
    private boolean beep;

    /**
     * Constructs a talking clock
     *
     * @param interval the interval between messages (in milliseconds)
     * @param beep     true if the clock should beep
     */
    private TalkingClock_v4(int interval, boolean beep) {
        this.interval = interval;
        this.beep = beep;
    }

    /**
     * Starts the clock.
     */
    private void start() {
        TimerEventsPrinter timerEventsListener = new TimerEventsPrinter();
        Timer t = new Timer(interval, timerEventsListener);
        t.start();
    }

    private class TimerEventsPrinter implements ActionListener {

        TimerEventsPrinter(){} //TODO: note - now no extra parameters needed... why?
        /**
         * Invoked when an action occurs.
         *
         * @param e - the event to react ...
         */
        @Override
        public void actionPerformed(ActionEvent e) {
            System.out.println("At the tone, the time is " + new Date());
//            if (beep) //TODO: how can we read beep here?
            if (TalkingClock_v4.this.beep) // or just if (beep)...
                Toolkit.getDefaultToolkit().beep();
        }
    }

    public static void main(String[] args) {
        new TalkingClock_v4(1000, true).start();
        // keep program running until user selects "Ok"
        JOptionPane.showMessageDialog(null, "Quit program?");
        System.exit(0);
    }
}
