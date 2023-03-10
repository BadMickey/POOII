package Models;

public class VinhoBranco {
	public String TeorAlcoolico;
	public String Tipo = "Vinho Branco";
	public String DataFabricacao;
	public String TamanhoGarrafa;
	public boolean Industrial;
	public boolean Artesanal;
	
	public VinhoBranco(String TeorAlcoolico, String Tipo, String DataFabricacao, String TamanhoGarrafa, boolean Industrial, boolean Artesanal) {
		this.TeorAlcoolico = TeorAlcoolico;
		this.Tipo = Tipo;
		this.DataFabricacao = DataFabricacao;
		this.TamanhoGarrafa = TamanhoGarrafa;
		this.Industrial = Industrial;
		this.Artesanal = Artesanal;
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
	
	
}
