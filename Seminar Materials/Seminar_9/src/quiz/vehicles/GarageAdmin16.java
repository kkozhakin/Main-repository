package quiz.vehicles;

class C{}

public class GarageAdmin16 {
    private Object object = new Object();
    private Vehicle vehicle = new Vehicle();
    private Car car = new Car();
    private Sedan sedan = new Sedan();

//    @SuppressWarnings("unchecked")
    public void doE(Garage<? super Car> garage) {
//        garage.put(object);
//        garage.put(vehicle);
        garage.put(car);
        garage.put(sedan);

        object = garage.get();
//        vehicle = garage.get();
//        car = garage.get();
//        sedan = garage.get();
    }
}
