import Interfaces.IVinhos;

public class Vinho implements IVinhos{
    private String nome;
    private String teoralcoolico;
    private String tipo;
    private String datafabricacao;

    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }
    public String getTeorAlcoolico() {
        return teoralcoolico;
    }
    public void setTeorAlcoolico(String teoralcoolico) {
        this.teoralcoolico = teoralcoolico;
    }
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public String getDataFabricacao() {
        return datafabricacao;
    }
    public void setDataFabricacao(String datafabricacao) {
        this.datafabricacao = datafabricacao;
    }
}
