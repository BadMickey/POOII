package reflection;
import java.lang.reflect.*;

public class FactorySensor {
    public static void imprimirInformações(String className) {
        try{
            //Imprime o nome da classe
            Class<?> sensorClass = Class.forName(className);    
            System.out.println("Nome da classe é: " + sensorClass.getName());

            //Imprime os construtores da classe
            Constructor<?>[] constructors = sensorClass.getConstructors();
            System.out.println("Construtores da classe:");
            for (Constructor<?> constructor : constructors) {
                System.out.println(constructor);
            }

            //Imprime os métodos da classe
            Method[] methods = sensorClass.getMethods();
            System.out.println("Métodos da classe:");
            for (Method method : methods) {
                System.out.println("Nome do método: " + method.getName());
                System.out.println("Tipo do método: " + method.getReturnType().getName());
                Class<?>[] parameters = method.getParameterTypes();
                for(Class<?> parameter : parameters){
                    System.out.println("Tipo de parâmetro: " + parameter.getName());
                }

            }

            //Imprime os campos da classe
            Field[] fields = sensorClass.getDeclaredFields();
            System.out.println("Campos da classe:");
            for (Field field : fields) {
                System.out.println(field);
            }
        }catch(ClassNotFoundException e){
            System.out.println("Classe não encontrada"+ e.getMessage());
        }
        
    }

    public static void verificarApitar(String className) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        try{
            Class<?> sensorClass = Class.forName(className);    
            Constructor<?> constructor = sensorClass.getConstructor(Boolean.class);
            Sensor sensor = (Sensor) constructor.newInstance(false);
        
            Method getStatusMethod = sensorClass.getMethod("getApitando");    
            boolean status = (boolean) getStatusMethod.invoke(sensor);
            if(status){
                System.out.println("O sensor está apitando");                          
         }
            else{
                System.out.println("O sensor não está apitando");                          
            }
        }catch(ClassNotFoundException e){
            System.out.println("Classe não encontrada"+ e.getMessage());
        }
    }

    public static void mudarStatus(String className)throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        try{
            Class<?> sensorClass = Class.forName(className);    
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
        }catch(ClassNotFoundException e){
            System.out.println("Classe não encontrada"+ e.getMessage());
        }    
    }
}
