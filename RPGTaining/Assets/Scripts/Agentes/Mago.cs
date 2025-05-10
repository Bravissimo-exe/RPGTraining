using System;
using UnityEngine;

public class Mago : PortadorJugable
{
    public Mago(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades)
    {
        sistemaDeHabilidades.añadirHabilidad(new BolaDeLuz("Bola de Luz"));
    }

}
