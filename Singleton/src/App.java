import Interfaces.VinhoSingleton;

public class App {
    public static void main(String[] args) throws Exception {

        VinhoSingleton vinho1 = VinhoSingleton.getVinhoInstance();
        vinho1.setVinhoModel("Cantina da serra");

        VinhoSingleton vinho2 = VinhoSingleton.getVinhoInstance();
        vinho2.setVinhoModel("Cantina da serra1");

        VinhoSingleton vinho3 = VinhoSingleton.getVinhoInstance();
        vinho3.setVinhoModel("Cantina da serra2");

        System.out.println("O model vinho do vinho 1 é: "+vinho1.getVinhoModel());
        System.out.println("O model vinho do vinho 2 é: "+vinho2.getVinhoModel());
        System.out.println("O model vinho do vinho 3 é: "+vinho3.getVinhoModel());
    }
}
