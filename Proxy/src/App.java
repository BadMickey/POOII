import Interfaces.ILogins;

public class App {
    public static void main(String[] args) throws Exception {
        ILogins logins = new LoginProxy();
        logins.login("user 1", "senha1");
        logins.login("user 3", "senha1");

    }
}
