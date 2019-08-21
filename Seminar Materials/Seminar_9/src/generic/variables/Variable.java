package generic.variables;

/**
 */
public class Variable <T> {

    private T value;

    public Variable(){
        this(null);
    }

    public Variable(T initValue){
        setValue(initValue);
    }

    public void setValue(T newValue){
        value = newValue;
    }
    public T getValue(){
        return value;
    }

}


