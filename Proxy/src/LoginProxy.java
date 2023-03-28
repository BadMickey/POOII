import Interfaces.ILogins;
import java.util.ArrayList;
import java.util.List;

public class LoginProxy implements ILogins{
    private List<String> usuariosSemPerm = new ArrayList<>();
    private Login login = new Login();

    public LoginProxy(){
        usuariosSemPerm.add("user 1");
        usuariosSemPerm.add("user 2");

    }
    @Override
    public void login(String usuario, String senha){
        if(usuariosSemPerm.contains(usuario)){
            System.out.println("Usuário sem acesso "+usuario);
        }
        else {
            login.login(usuario, senha);
        }
    }
}
