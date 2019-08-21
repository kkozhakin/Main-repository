package generic.variables;

/*
    TODO: What might be the sense to define that class comparing with its base class Variable<T> ?
 */

class NumberVariable <T extends Number> extends Variable<T> {

    private T value;

    public NumberVariable(){
        this(null);
    }
    NumberVariable(T initValue){
        setValue(initValue);
    }

    public void setValue(T newValue){
        value = newValue;
    }
    public T getValue(){
        return value;
    }

    public boolean isSameDoubleValue(NumberVariable<?> someObject){
        return this.getValue().doubleValue() == someObject.getValue().doubleValue();
    }
    public boolean isSameLongValue(NumberVariable<?> someObject){
        return this.getValue().longValue() == someObject.getValue().longValue();
    }
}

