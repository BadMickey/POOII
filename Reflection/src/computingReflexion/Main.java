package computingReflexion;

public class Main {
    public static void main(String[] args) {
        do{
            CarFactory.createCar("computingReflexion.Car");
                
            if (CarFactory.finishFactory().equals("y")){
                break;
            }
        } while(true);
    }
}
