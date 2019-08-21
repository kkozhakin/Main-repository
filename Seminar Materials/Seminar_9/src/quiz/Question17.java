package quiz;

import java.io.Serializable;

public class Question17 { }

class ClassA<U> implements Comparable<U>{
    public int compareTo(U o) {
        return 0;
    }
}

//class ClassB<U,V> extends ClassA<R>{}
class ClassC<U,V> extends ClassA<U>{}
//class ClassD<U,V> extends ClassA<U,V>{}
class ClassE<U> extends ClassA<Comparable<Number>>{}
class ClassF<U extends Comparable<U> & Serializable> extends ClassA<Number>{}
//class ClassG<U implements Comparable<U>> extends ClassA<Number>{}
//class ClassH<U extends Comparable<U>> extends ClassA<? extends Number>{}
//class ClassI<U extends String & Comparable<U>> extends ClassA<U>{}
//class ClassJ<U extends ClassA<Integer>> implements Comparable<Number>{}