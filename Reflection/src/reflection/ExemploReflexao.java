package reflection;
import java.lang.reflect.*;

public class ExemploReflexao {

    public static void main(String[] args) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException{
        FactorySensor.imprimirInformações();
        FactorySensor.mudarStatus();
        FactorySensor.verificarApitar();
    }
}
