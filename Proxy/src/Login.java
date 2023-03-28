import Interfaces.ILogins;

public class Login implements ILogins{
    
    @Override
    public void login(String usuario, String senha){
        System.out.println("Fazendo login com usuario " +usuario+ " e senha "+senha);
    }
}
