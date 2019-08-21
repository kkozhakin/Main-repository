package sample_2.reflection;

public class ArrayInterfacesTest {

    public static void main(String[] args) {
        if(args == null || args.length != 1 || args[0] == null){
            System.out.println("Error: args[0] must contain array type name.");
            System.exit(1);
        }
        try{
            Class c = Class.forName(args[0]);
            Class[] interfaces = c.getInterfaces();
            for (int i = 0; i < interfaces.length ; i ++) {
                System.out.println("#" + (i + 1) + ": " + interfaces[i]);
            }
        } catch (Exception ex){
            System.out.println("Exception: " + ex);
        }
    }

}
