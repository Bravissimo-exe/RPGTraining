using System;
using System.Threading.Tasks;
using UnityEngine;

public enum TipoRegeneracion
{
    INSTANTANEA,
    PORTIEMPO
}

public class SistemaDeMana : SistemaDeEstadisticas
{
    private int manaPorSegundo;

    public SistemaDeMana(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual)
    {
    }
    public SistemaDeMana() { }

    public void RegenerarMana(int cantidad, TipoRegeneracion tipo)
    {
        switch (tipo)
        {
            case TipoRegeneracion.INSTANTANEA:
                AñadirMana(cantidad);
                break;

            case TipoRegeneracion.PORTIEMPO:
                RegenerarMana(cantidad);
                break;
        }
    }

    private void AñadirMana(int cantidad)
    {
        valorActual += cantidad;
        if (valorActual > valorMax)
            valorActual = valorMax;
    }

    private async void RegenerarMana(int cantidad)
    {
        int cantidadAñadida = 0;
        while (cantidadAñadida < cantidad)
        {
            cantidadAñadida += manaPorSegundo;
            AñadirMana(manaPorSegundo);

            await Task.Delay(500); //Cura cada medio segundo
        }
    }

}
