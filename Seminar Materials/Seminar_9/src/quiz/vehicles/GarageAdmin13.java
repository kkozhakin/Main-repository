package quiz.vehicles;

class Vehicle{}
class Car extends Vehicle{}
class Sedan extends Car{}

class Garage<V>{
    private V v;
    public void put(V v) {
        this.v = v;
    }
    public V get(){
        return v;
    }
}

public class GarageAdmin13 {
    private Object object = new Object();
    private Vehicle vehicle = new Vehicle();
    private Car car = new Car();
    private Sedan sedan = new Sedan();

//    @SuppressWarnings("unchecked")
    public void doA(Garage garage){
        garage.put(object);
        garage.put(vehicle);
        garage.put(car);
        garage.put(sedan);

        object = garage.get();
//        vehicle = garage.get();
//        car = garage.get();
//        sedan = garage.get();
    }
}
