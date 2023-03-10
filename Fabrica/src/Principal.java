import java.util.ArrayList;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;

import Models.VinhoTinto;

public class Principal {

	public static void main(String[] args) {
        String diretorio = "C:\\Users\\leona\\OneDrive\\Área de Trabalho\\teste\\Dados.txt";
        List<VinhoTinto> ListaVinhos = new ArrayList<>();
        
        try (FileReader fr = new FileReader(diretorio);
             BufferedReader br = new BufferedReader(fr)) {
        	
            String linha;
            while((linha = br.readLine()) != null) {
            	if(linha != "") {
            		String[] info = linha.split(",");
                	String TeorAlcoolico = info[0];
                	String Tipo = info[1];
                	String DataFabricacao = info[2];
                	String TamanhoGarrafa = info[3];
                	boolean Industrial = Boolean.parseBoolean(info[4]);
                	boolean Artesanal = Boolean.parseBoolean(info[5]);
                	
                	VinhoTinto vinho = new VinhoTinto(TeorAlcoolico, Tipo, DataFabricacao, TamanhoGarrafa, Industrial, Artesanal);
                	ListaVinhos.add(vinho);
            	}
            }
        }
        catch(IOException e){
        	System.out.printf("Arquivo não encontrado");
        }
        for (VinhoTinto vinho : ListaVinhos) {
			System.out.printf("Teor Alcoolico: "+vinho.TeorAlcoolico+"\n");
			System.out.printf("Tipo: "+vinho.Tipo+"\n");
			System.out.printf("Data Fabricao: "+vinho.DataFabricacao+"\n");
			System.out.printf("Tamanho da Garrafa: "+vinho.TamanhoGarrafa+"\n");
			System.out.printf("Industrial: "+vinho.Industrial+"\n");
			System.out.printf("Artesanal: "+vinho.Artesanal+"\n");
			System.out.println();
		}
	}
}
