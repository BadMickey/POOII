import Interfaces.PrototypeConcreto;

public class App {
    public static void main(String[] args) throws Exception {
        PrototypeConcreto prototipo1 = new PrototypeConcreto(1);
        PrototypeConcreto prototipo2 = prototipo1.copia();

        System.out.println("Valor do prototipo 1: "+prototipo1.getValor());
        System.out.println("Valor do prototipo 2: "+prototipo1.getValor());

    }
}
