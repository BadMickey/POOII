package reflection;
import java.lang.reflect.*;
import java.util.Scanner;

public class ExemploReflexao {

    public static void main(String[] args) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException{
        Scanner read = new Scanner(System.in);

        System.out.println("Digite qual opção de comando deseja: ");
        System.out.println(" 1 - imprimir as informações; 2 - verificar sensor; 3 - mudar os status do sensor");
        int option = read.nextInt();

        switch (option) {
            case 1:
                FactorySensor.imprimirInformações("reflection.Sensor");
                break;
            case 2:
                FactorySensor.verificarApitar("reflection.Sensor");
                break;
            case 3:
                FactorySensor.mudarStatus("reflection.Sensor");
                break;
            default:
                System.out.println("Opção não encontrada, executa o programa novamente!");
                break;
        }
    }
}
