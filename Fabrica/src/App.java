import Interfaces.FabricaVinhos;
import Models.VinhoBranco;
import Models.VinhoTinto;
import java.util.Scanner;
import Fabrica.FabricaVinhosArtesanal;
import Fabrica.FabricaVinhosIndustrial;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        Scanner ler = new Scanner(System.in);
        //FabricaVinhos fabrica = new 
        System.out.println("Seja bem-vindo a nossa fábrica de vinhos!");
        System.out.println("Primeiro vamos definir o que iremos fabricar: ");
        System.out.println("1 - para fabricar vinho artesanal e 2 - para fabricar vinho industrial");
        int tipofabrica = ler.nextInt();
        
        switch (tipofabrica) 
        {
            case 1:
                System.out.println("Digite o diretorio do arquivo .txt, ele deve seguir o padrão: nome;teoralcoolico;data;tamanho");
                ler.nextLine();
                String arquivo = ler.nextLine();
                FabricaVinhos fabrica = new FabricaVinhosArtesanal(arquivo);
                System.out.println("Digite o tipo do vinho a ser fabricado: Tinto ou Branco");
                String Tipo = ler.nextLine();
                
                if(Tipo.equalsIgnoreCase("branco"))
                {
                    VinhoBranco vinhoBranco = fabrica.fabricarVinhoBranco();
                    System.out.println("O rótulo do vinho é: ");
                    vinhoBranco.rotulo();
                }
                else if(Tipo.equalsIgnoreCase("tinto"))
                {
                    VinhoTinto vinhoTinto = fabrica.fabricarVinhoTinto();
                    System.out.println("O rótulo do vinho é: ");
                    vinhoTinto.rotulo();
                }
                break;
            case 2:
                System.out.println("Digite o diretorio do arquivo .txt, ele deve seguir o padrão: nome;teoralcoolico;data;tamanho");
                ler.nextLine();
                String arquivo2 = ler.nextLine();
                FabricaVinhos fabrica2 = new FabricaVinhosIndustrial(arquivo2);
                System.out.println("Digite o tipo do vinho a ser fabricado: Tinto ou Branco");
                String Tipo2 = ler.nextLine();
                
                if(Tipo2.equalsIgnoreCase("branco"))
                {
                    VinhoBranco vinhoBranco = fabrica2.fabricarVinhoBranco();
                    System.out.println("O rótulo do vinho é: ");
                    vinhoBranco.rotulo();
                }
                else if(Tipo2.equalsIgnoreCase("tinto"))
                {
                    VinhoTinto vinhoTinto = fabrica2.fabricarVinhoTinto();
                    System.out.println("O rótulo do vinho é: ");
                    vinhoTinto.rotulo();
                }
                break;
        }
    }
}
