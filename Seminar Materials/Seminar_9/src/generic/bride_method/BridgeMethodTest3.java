package generic.bride_method;

class Employee implements Cloneable{

    private String name;

    Employee(String name){
        this.name = name;
    }
    public Employee clone() throws CloneNotSupportedException {
        return (Employee) super.clone();
    }
    public String toString(){
        return super.toString() + ": name = " + name; // What will be happened without super here?
    }
}
/*
TODO: show synthetic bridge method in bytecode of Employee class...(they are used not only for generics ...)
TODO: note that synthetic bride methods are generated to implement covariant return types in Java (when overriding methods)...
 */
public class BridgeMethodTest3 {
    public static void main(String[] args) throws CloneNotSupportedException {
        Employee e1 = new Employee("Sidor");
        Employee e2 = e1.clone();
        System.out.println(e1);
        System.out.println(e2);
    }
}
