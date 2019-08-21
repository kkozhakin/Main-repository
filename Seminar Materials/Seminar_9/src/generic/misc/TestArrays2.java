package generic.misc;

import generic.variables.Variable;

import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

// Sample classes and interfaces:
class A {}
class B extends A{}
interface I{}
class C extends B implements I{}

class Fish{}
class Herring extends Fish{}
class Shark extends Fish{}

/*
    TODO: note that java arrays and generic object wrappers (Variable(s)) behave differently...
 */

public class TestArrays2 {
    public static void main(String[] args) {
        AutoCloseable[] autoCloseables;
        PrintStream[] printStreams = new PrintStream[0];
        System.out.println(Arrays.toString(printStreams));
        autoCloseables = printStreams; //TODO: note - it's ok since PrintStream implements AutoCloseable
        System.out.println(Arrays.toString(autoCloseables));

        A[] as = new A[]{new A(), new A()};
        B[] bs = new B[]{new B(), new B()};
        I[] is = new I[]{new C(), new C()};
        C[] cs = new C[]{new C(), new C()};

// TODO: note - if we have an array of fishes we can deal with array of herrings:
        as = bs; //ok
        as = cs; //ok
        is = cs; //ok

//TODO:  but: if we have a variable for fish, it does not mean that we can replace it with a variable for herrings...
        Variable<Fish> fishVariable = new Variable<>();
        Variable<Herring> herringVariable = new Variable<>();
        Variable<Shark> sharkVariable = new Variable<>();
//TODO all the following - demonstrate incompatible types (compile errors):
//        fishVariable = herringVariable;
//        fishVariable = sharkVariable;
//        herringVariable = sharkVariable;
//        sharkVariable = fishVariable;
        List<Fish> fishList = new ArrayList<>();
        List<Herring> herringList = new ArrayList<>();
        List<Shark> sharkList = new ArrayList<>();
//TODO all the following - demonstrate incompatible types (compile errors):
//        fishList = herringList;
//        fishList = sharkList;
//        herringList = sharkList;
//        sharkList = fishList;
    }
}
