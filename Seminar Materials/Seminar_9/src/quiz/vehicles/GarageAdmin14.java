package quiz.vehicles;

class A{}

public class GarageAdmin14 {
    private Object object = new Object();
    private Vehicle vehicle = new Vehicle();
    private Car car = new Car();
    private Sedan sedan = new Sedan();

//    @SuppressWarnings("unchecked")
    public void doC(Garage<?> garage) {
//        garage.put(object);
//        garage.put(vehicle);
//        garage.put(car);
//        garage.put(sedan);

        object = garage.get();
//        vehicle = garage.get();
//        car = garage.get();
//        sedan = garage.get();
    }
}
