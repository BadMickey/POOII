package computingReflexion;
import java.lang.reflect.Constructor;
import java.lang.reflect.Method;
import java.util.Scanner;

public class CarFactory {
    public static void createCar(String className) {
        try {
            Class<?> carClass = Class.forName(className);
            Constructor<?> constructor = carClass.getDeclaredConstructor(String.class, String.class, int.class, String.class);
            Method method = carClass.getDeclaredMethod("configSpeed", int.class);
            
            Scanner scanner = new Scanner(System.in);
            System.out.print("\nInforme a quantidade para a produção: ");
            int qtd = Integer.parseInt(scanner.nextLine());
            System.out.print("Informe a marca do carro: ");
            String brand = scanner.nextLine();
            System.out.print("Informe o modelo do carro: ");
            String model = scanner.nextLine();
            System.out.print("Informe o ano do carro: ");
            int year = Integer.parseInt(scanner.nextLine());
            System.out.print("Informe a cor do carro: ");
            String color = scanner.nextLine();
            System.out.print("Informe a velocidade máxima: ");
            int maxSpeed = Integer.parseInt(scanner.nextLine());

            for (int i = 0; i < qtd; i++){
                Object carInstance = constructor.newInstance(brand, model, year, color);
                
                System.out.println("\n\nNovo carro criado !!");
    
                method.setAccessible(true);
                method.invoke(carInstance, maxSpeed);
            }
            
        } catch (ClassNotFoundException e) {
            System.out.println("Classe não encontrada: " + e.getMessage());
        } catch (NoSuchMethodException e) {
            System.out.println("Construtor adequado não encontrado: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("Erro ao criar instância do carro ou invocar o método: " + e.getMessage());
        }
    }


    public static String finishFactory(){
        Scanner scanner = new Scanner(System.in);
        System.out.print("Deseja encerrar a fábrica? [y/n]: ");
        String answer = scanner.nextLine();

        return answer;
    }
}
