package quiz.vehicles;

class B{}

public class GarageAdmin15 {
    private Object object = new Object();
    private Vehicle vehicle = new Vehicle();
    private Car car = new Car();
    private Sedan sedan = new Sedan();

//    @SuppressWarnings("unchecked")
    public void doC(Garage<? extends Car> garage) {
//        garage.put(object);
//        garage.put(vehicle);
//        garage.put(car);
//        garage.put(sedan);

        object = garage.get();
        vehicle = garage.get();
        car = garage.get();
//        sedan = garage.get();
    }

}
