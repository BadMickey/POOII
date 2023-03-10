package Interfaces;

import Models.VinhoBranco;
import Models.VinhoTinto;

public interface FabricaVinhos {
    public VinhoBranco fabricarVinhoBranco();
    public VinhoTinto fabricarVinhoTinto();
}
