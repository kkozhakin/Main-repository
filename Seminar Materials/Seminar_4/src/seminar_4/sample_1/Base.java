package seminar_4.sample_1;

/**
 *  TODO: uncomment (one by one) access specifiers at f() and explain the difference for private...
 */
public class Base {
    // Print with a newline:
    static void print(Object obj) {
        System.out.println(obj.toString());
    }

//    Base(){
//        this.f();
//    }

//  public
//  protected
  private
    void f() {
        print(" base f()");
    }

    public static void main(String[] args) {
        Base po = new Derived();
        po.f();
    }
}

class Derived extends Base {
 //   @Override
    public void f() {
        print(" derived f()");
    }
}

