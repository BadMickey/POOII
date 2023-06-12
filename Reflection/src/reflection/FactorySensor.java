package reflection;
import java.lang.reflect.*;

public class FactorySensor {
    public static void imprimirInformações() {
        Class<?> sensorClass = Sensor.class;

        // Mostra o nome da classe 
        System.out.println("Nome da classe: " + sensorClass.getName());


        // Mostra o construtores da classe
        Constructor<?>[] constructors = sensorClass.getConstructors();
        System.out.println("Construtores da classe:");
        for (Constructor<?> constructor : constructors) {
            System.out.println(constructor);
        }

        // Mostra os métodos da classe
        Method[] methods = sensorClass.getMethods();
        System.out.println("Métodos da classe:");
        for (Method method : methods) {
            System.out.println(method);
        }

        // Mostra os campos da classe
        Field[] fields = sensorClass.getDeclaredFields();
        System.out.println("Campos da classe:");
        for (Field field : fields) {
            System.out.println(field);
        }
    }

    public static void verificarApitar() throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        Class<?> sensorClass = Sensor.class;
        Constructor<?> constructor = sensorClass.getConstructor(boolean.class);
        Sensor sensor = (Sensor) constructor.newInstance(false);
        
        Method getStatusMethod = sensorClass.getMethod("getApitando");    
        boolean status = (boolean) getStatusMethod.invoke(sensor);
        if(status){
            System.out.println("O sensor está apitando");                          
        }
        else{
            System.out.println("O sensor não está apitando");                          
        }
    }

    public static void mudarStatus()throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException{
        Class<?> sensorClass = Sensor.class;
        Constructor<?> constructor = sensorClass.getConstructor(Boolean.class);
        Sensor sensor = (Sensor) constructor.newInstance(false);
        
        Method getStatusMethod = sensorClass.getMethod("getApitando");    
        boolean status = (boolean) getStatusMethod.invoke(sensor);       
        Method setStatusMethod = sensorClass.getMethod("setApitando", Boolean.class);
        if(status){
            setStatusMethod.invoke(sensor, false);
            System.out.println("O sensor agora não está mais apitando");    
        }
        else{
            setStatusMethod.invoke(sensor, true);
            System.out.println("O sensor agora está apitando");
        }    
    }
}
