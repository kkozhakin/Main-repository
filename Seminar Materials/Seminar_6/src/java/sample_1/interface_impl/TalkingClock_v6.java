package sample_1.interface_impl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Date;

/**
 *  TODO: now we use anonymous inner class in start()-method: no sense to name it (it is not used elsewhere...)
 */
class TalkingClock_v6 {

    /**
     * Starts the clock.
     * @param interval the interval between messages (in milliseconds)
     * @param beep true if the clock should beep
     */
    private void start(int interval,boolean beep){
//         beep = !beep; //todo: uncomment & explain it...
        //TODO: show automated change into lambda by IntelliJ Idea...
         ActionListener listener = new ActionListener() {
            public void actionPerformed(ActionEvent event) {
                System.out.println("At the tone, the time is " + new Date());
                if (beep)
                    Toolkit.getDefaultToolkit().beep();
            }
         };
         Timer t = new Timer(interval, listener);
         t.start();
    }

    public static void main(String[] args) {
        TalkingClock_v6 clock_v6 = new TalkingClock_v6();
        boolean b = args.length == 0;
        int interval = (args.length == 0)? 1000 : 2000;
        clock_v6.start(interval, b);
        JOptionPane.showMessageDialog(null, "Quit program?");
        System.exit(0);
    }
}
