package sample_4;

/**
 * TODO: answer - what should be printed and why ? Explain - what's happening...
 * TODO: see sample on how to lean in depth:
 * http://dolzhenko.blogspot.com/2009/07/java-final.html
 */

class A {
   A() {
      System.out.println("this.getClass() : "  + this.getClass());
      init();
   }
   public void init() {
   }
}

class B extends A {

   private final Integer i = 1; //Integer.valueOf(1); // at init() is not inited yet...
   private final int ii = 320000;                     // (as statically known by compiler it is inlined in methods...!!!)
   private int iii = 3;                               // at init() is not inited yet...

   B() {
      super();
   }

   public void init() {
      System.out.println(" i = " + i);
      System.out.println(" ii = " + ii);
      System.out.println(" iii = " + iii);
   }

   public Integer getI() {
      return i;
   }
   public int getIi() {
      return ii;
   }
   public int getIii(){
      return iii;
   }
}

public class InitTest {
   public static void main(String[] args){
      B b = new B();
      System.out.println(" i = " + b.getI());
      System.out.println(" ii = " + b.getIi());
      System.out.println(" iii = " + b.getIii());

   }
}
