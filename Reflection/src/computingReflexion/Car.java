package computingReflexion;

public class Car {
    private String brand;
    private String model;
    private int year;
    private String color;
    private double speed;

    public Car(String brand, String model, int year, String color) {
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.color = color;
        this.speed = 0.0;
    }

    private void configSpeed(int maxSpeed){
        this.speed = maxSpeed;
        System.out.println("\nVelocidade máxima configurada. \nTestando motor.\n");
        for (int i = 0; i <= maxSpeed * 0.9; i += 6){
            System.out.println("Velocidade atual: " + i);
        }
        System.out.println("\nMotor configurado e testado.");
    }
}
