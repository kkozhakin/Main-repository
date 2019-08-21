package method_ref;

interface MyFunc<T> {
    boolean func(T v1, T v2);
}

class HighTemp {
    private int hTemp;

    HighTemp(int ht) {
        hTemp = ht;
    }
    boolean sameTemp(HighTemp highTemp){
        return (hTemp == highTemp.hTemp);
    }
    boolean lessThanTemp(HighTemp highTemp){
        return (hTemp < highTemp.hTemp);
    }
}

public class MethodRefDemo_4_DifferentObjects {

    private static <T> int counter (T[] vals, MyFunc<T> f, T v){
        int count = 0;
        for (T val : vals) {
            if (f.func(val, v))
                count++;
        }
        return count;
    }

    public static void main(String[] args) {
        int count;
        HighTemp[] weekDayHighs =
          {new HighTemp(20), new HighTemp(21), new HighTemp(23), new HighTemp(24), new HighTemp(25), new HighTemp(25)};
        count = counter(weekDayHighs, HighTemp::sameTemp, new HighTemp(25));
        System.out.println(count + " days had a high of 25");
    }
}
