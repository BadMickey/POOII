package Interfaces;
public class PrototypeConcreto implements IPrototype{
    private int valor;

    public PrototypeConcreto(int valor){
        this.valor = valor;
    }

    public PrototypeConcreto copia(){
        return new PrototypeConcreto(valor);
    }

    public int getValor(){
        return valor;
    }
}
