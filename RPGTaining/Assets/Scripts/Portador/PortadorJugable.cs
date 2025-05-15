using UnityEngine;

public class PortadorJugable : Portador
{
    protected string nombre;
    protected SistemaDeMana sistemaDeMana;
    protected SistemaDeHabilidades sistemaDeHabilidades;

    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(sistemaDeVida)
    {
        this.nombre = nombre;
        this.sistemaDeVida = sistemaDeVida;
        this.sistemaDeMana = sistemaDeMana;
        this.sistemaDeHabilidades = sistemaDeHabilidades;
    }

    void Awake()
    {
    }
}
