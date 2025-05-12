using UnityEngine;

public class Nigromante : PortadorJugable
{
    
    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeHabilidades)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AñadirVidaUi(this.gameObject, sistemaVida.valorActual, sistemaVida.valorMax);
    }

    // Update is called once per frame
    void Update()
    {
        sistemaVida.ActualizarVida(sistemaVida.valorActual, sistemaVida.valorMax);
    }
}
