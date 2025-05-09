using UnityEngine;

public class SistemaDeVida : SistenaDeEstadisticas
{
    public virtual void regenerarVida(int cantidad){
        valorActual += cantidad;
    }
}
