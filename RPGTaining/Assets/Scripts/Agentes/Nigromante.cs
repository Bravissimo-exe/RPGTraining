using UnityEngine;
public class Nigromante : PortadorJugable
{
    public Collider colision;
    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, null, sistemaDeHabilidades)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sistemaDeVida.ValorActual);
        sistemaDeVida.ActualizarVida(sistemaDeVida.ValorActual);
        
    }
}
