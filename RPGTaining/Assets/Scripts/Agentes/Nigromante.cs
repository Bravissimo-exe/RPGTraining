using Unity.VisualScripting;
using UnityEngine;

public class Nigromante : PortadorJugable
{
    
    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeHabilidades)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AñadirVidaUiJugador(this.gameObject, sistemaVida.valorMax);
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarVida(sistemaVida.valorActual);
    }
}
