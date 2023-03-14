package Fabrica;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import Interfaces.FabricaVinhos;
import Models.VinhoBranco;
import Models.VinhoTinto;

public class FabricaVinhosArtesanal implements FabricaVinhos{
    private String Diretorio;

    public FabricaVinhosArtesanal(String Diretorio){
        this.Diretorio = Diretorio;
    }

    @Override
    public VinhoBranco fabricarVinhoBranco() {
        VinhoBranco vinhoBranco = null;
        try{
            FileReader fr = new FileReader(Diretorio);
            BufferedReader br = new BufferedReader(fr);
            String linha = br.readLine();
            String[] dados = linha.split(";");
            String nome = dados[0];
            String teoralcoolico = dados[1];
            String tipo = "Branco";
            String data = dados[2];
            String tamanho = dados[3];
            boolean industrial = false;
            boolean artesanal = true;
            vinhoBranco = new VinhoBranco(nome, teoralcoolico, tipo, data, tamanho, industrial, artesanal);
            br.close();
            fr.close();
        }catch(IOException err){
            err.printStackTrace();
        }
        return vinhoBranco;
    }

    @Override
    public VinhoTinto fabricarVinhoTinto() {
        VinhoTinto vinhoTinto = null;
        try{
            FileReader fr = new FileReader(Diretorio);
            BufferedReader br = new BufferedReader(fr);
            String linha = br.readLine();
            String[] dados = linha.split(";");
            String nome = dados[0];
            String teoralcoolico = dados[1];
            String tipo = "Tinto";
            String data = dados[2];
            String tamanho = dados[3];
            boolean industrial = false;
            boolean artesanal = true;
            vinhoTinto = new VinhoTinto(nome, teoralcoolico, tipo, data, tamanho, industrial, artesanal);
            br.close();
            fr.close();
        }catch(IOException err){
            err.printStackTrace();
        }
        return vinhoTinto;
    }
}
