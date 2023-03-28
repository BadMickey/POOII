package Interfaces;

public class VinhoSingleton implements IVinho{
    private static VinhoSingleton vinho_instance = null;

    private String VinhoModel;

    public static synchronized VinhoSingleton getVinhoInstance(){
        if(vinho_instance ==null){
            vinho_instance = new VinhoSingleton();
        }
        return vinho_instance;
    }
    public void setVinhoModel(String VinhoModel){
        this.VinhoModel = VinhoModel;
    }
    
    public String getVinhoModel(){
        return VinhoModel;
    }
}
