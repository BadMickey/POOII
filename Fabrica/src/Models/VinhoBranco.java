package Models;

public class VinhoBranco {
	public String Nome;
	public String TeorAlcoolico;
	public String Tipo;
	public String DataFabricacao;
	public String TamanhoGarrafa;
	public boolean Industrial;
	public boolean Artesanal;
	
	public VinhoBranco(String Nome, String TeorAlcoolico, String Tipo, String DataFabricacao, String TamanhoGarrafa, boolean Industrial, boolean Artesanal) {
		this.Nome = Nome;
		this.TeorAlcoolico = TeorAlcoolico;
		this.Tipo = Tipo;
		this.DataFabricacao = DataFabricacao;
		this.TamanhoGarrafa = TamanhoGarrafa;
		this.Industrial = Industrial;
		this.Artesanal = Artesanal;
	}
	
	public String getNome() {
		return Nome;
	}

	public void setNome(String nome) {
		Nome = nome;
	}

	public String getTipo() {
		return Tipo;
	}

	public void setTipo(String tipo) {
		Tipo = tipo;
	}

	public String getTeorAlcoolico() {
		return TeorAlcoolico;
	}

	public void setTeorAlcoolico(String teorAlcoolico) {
		TeorAlcoolico = teorAlcoolico;
	}

	public String getDataFabricacao() {
		return DataFabricacao;
	}

	public void setDataFabricacao(String dataFabricacao) {
		DataFabricacao = dataFabricacao;
	}

	public String getTamanhoGarrafa() {
		return TamanhoGarrafa;
	}

	public void setTamanhoGarrafa(String tamanhoGarrafa) {
		TamanhoGarrafa = tamanhoGarrafa;
	}

	public boolean isIndustrial() {
		return Industrial;
	}

	public void setIndustrial(boolean industrial) {
		Industrial = industrial;
	}

	public boolean isArtesanal() {
		return Artesanal;
	}

	public void setArtesanal(boolean artesanal) {
		Artesanal = artesanal;
	}
	
	public void rotulo()
	{
		if(Industrial == true)
		{
			System.out.println("----------------Rótulo----------------");
			System.out.println("Nome: "+Nome);
			System.out.println("Teor alcoolico: "+TeorAlcoolico);
			System.out.println("Tipo: "+Tipo);
			System.out.println("Data de Fabricação: "+DataFabricacao);
			System.out.println("Tamanho da Garrafa: "+TamanhoGarrafa);
			System.out.println("Vinho industrializado");
		}
		else if (Artesanal == true)
		{
			System.out.println("----------------Rótulo----------------");
			System.out.println("Nome: "+Nome);
			System.out.println("Teor alcoolico: "+TeorAlcoolico);
			System.out.println("Tipo: "+Tipo);
			System.out.println("Data de Fabricação: "+DataFabricacao);
			System.out.println("Tamanho da Garrafa: "+TamanhoGarrafa);
			System.out.println("Vinho Artesanal");
		}
		else
		{
			System.out.println("O vinho informado não se adequa ao tipo de fabricação: Industrial ou Artesanal");
		}
	}
}
