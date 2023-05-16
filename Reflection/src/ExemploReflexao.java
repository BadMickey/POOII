import java.lang.reflect.*;

public class ExemploReflexao {

    public static void main(String[] args) {
        Class classe = Pessoa.class;

        // Obter o nome da classe
        String nomeClasse = classe.getName();
        System.out.println("Nome da classe: " + nomeClasse);

        // Obter os campos da classe
        Field[] campos = classe.getDeclaredFields();
        for (Field campo : campos) {
            System.out.println("Campo: " + campo.getName());
        }

        // Obter os métodos da classe
        Method[] metodos = classe.getDeclaredMethods();
        for (Method metodo : metodos) {
            System.out.println("Método: " + metodo.getName());
        }
    }
}
