public class App {
    public static void main(String[] args) throws Exception {
        VinhoBuilder builder = new VinhoBuilder();
        builder.setNome("Cantina da serra");
        builder.setTeorAlcoolico("10%");
        builder.setTipo("Tinto");
        builder.setDataFabricacao("10/03/2020");
        Vinho vinho = builder.build();

        System.out.println("Nome: " +vinho.getNome());
        System.out.println("Teor Alcoolico: " +vinho.getTeorAlcoolico());
        System.out.println("Tipo: " +vinho.getTipo());
        System.out.println("Data Fabricação: " +vinho.getDataFabricacao());
    }
}
