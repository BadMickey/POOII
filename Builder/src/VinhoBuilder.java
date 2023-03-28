import Interfaces.IVinhos;

public class VinhoBuilder implements IVinhos{
    private Vinho vinho;

    public VinhoBuilder(){
        vinho = new Vinho();
    }

    public void setNome(String nome) {
        vinho.setNome(nome);
    }

    public void setTeorAlcoolico(String teoralcoolico) {
        vinho.setTeorAlcoolico(teoralcoolico);
    }

    public void setTipo(String tipo) {
        vinho.setTipo(tipo);
    }

    public void setDataFabricacao(String datafabricacao) {
        vinho.setTipo(datafabricacao);
    }
    
    public Vinho build(){
        return vinho;
    }
}
