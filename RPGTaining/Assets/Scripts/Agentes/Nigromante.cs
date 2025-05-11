using UnityEngine;

public class Nigromante : PortadorJugable
{
    
    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeHabilidades)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sistemaDeVida.ActualizarVida(sistemaDeVida.ValorActual, sistemaDeVida.ValorMax);
    }
}
