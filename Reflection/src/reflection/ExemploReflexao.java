package reflection;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Constructor;

public class ExemploReflexao {

    public static void main(String[] args) {
        Class<?> sensorClass = Sensor.class;

        // Obter o nome da classe
        System.out.println("Nome da classe: " + sensorClass.getName());

        // Obter os campos da classe
        Field[] fields = sensorClass.getDeclaredFields();
        System.out.println("Campos da classe:");
        for (Field field : fields) {
            System.out.println(field);
        }

        // Obter os métodos da classe
        Method[] methods = sensorClass.getMethods();
        System.out.println("Métodos da classe:");
        for (Method method : methods) {
            System.out.println(method);
        }

        try {
            // Criar uma instância do Sensor
            Sensor sensor = new Sensor();

            // Obter o campo "status"
            Field statusField = sensorClass.getDeclaredField("status");

            // Definir o campo como acessível para modificação
            statusField.setAccessible(true);

            // Obter o valor atual do campo
            boolean status = (boolean) statusField.get(sensor);
            System.out.println("Status atual: " + status);

            // Alterar o valor do campo
            statusField.set(sensor, !status);

            // Verificar o novo valor do campo
            status = (boolean) statusField.get(sensor);
            System.out.println("Novo status: " + status);
        } catch (InstantiationException | IllegalAccessException e) {
            e.printStackTrace();
        }

    }
}
