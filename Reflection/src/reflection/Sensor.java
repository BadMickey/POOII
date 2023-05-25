package reflection;

public class Sensor {
    private String nomeIdentificador;
    private Boolean status;
    private Boolean apitando;

    public Sensor(String nomeIdentificador, Boolean status, Boolean apitando) {
        this.nomeIdentificador = nomeIdentificador;
        this.status = false;
        this.apitando = false;
    }

    public Boolean isStatus() {
        return status;
    }

    public void setStatus(Boolean status) {
        this.status = status;
    }

    public Boolean isApitando() {
        return apitando;
    }

    public void setApitando(Boolean apitando) {
        this.apitando = apitando;
    }

    public void alterarStatus(){
        this.status = !this.status;
        if(this.status == true){
            System.out.println("Sensor ativado!");
        }
        else{
            System.out.println("Sensor desativado!");
        }
    }
}
