/**
 * TODO:
 * 1.implement command line application that get input from args;
 * 2.implement the same, but reading input from System.in (and exit by "exit").
 * 3.Do the same with JOptionPane...
 *
 * all that means are covered in Horstman, v2. ch.3
 * TODO: do the same but converting Celseum to Farenheit...
 *
 */
public class KmToMiles {

    //========================================================= constants
    private static final double MILES_PER_KILOMETER = 0.621;

    //============================================================== main
    public static void main(String[] args) {
        double kms   = getDouble(args[0]);
        double miles = convertKmToMi(kms);
        displayString(kms + " kilometers is " + miles + " miles.");
    }

    //===================================================== convertKmToMi
    // Conversion method - kilometers to miles.
    private static double convertKmToMi(double kilometers) {
//        double miles = kilometers * MILES_PER_KILOMETER;
        return kilometers * MILES_PER_KILOMETER;
//        return miles;
    }

    //========================================================= getDouble
    // I/O convenience method to read a double value.
    private static double getDouble(String number) {
//        String tempStr;
//        tempStr = JOptionPane.showInputDialog(null, number);
        return Double.parseDouble(number);
    }

    //===================================================== displayString
    // I/O convenience method to display a string in dialog box.
    private static void displayString(String output) {

//        JOptionPane.showMessageDialog(null, output);
        System.out.println(output);
    }

}
