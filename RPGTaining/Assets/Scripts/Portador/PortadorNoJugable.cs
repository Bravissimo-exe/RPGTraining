using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador
{
    

    [SerializeField] private Slider barraVida;

    public PortadorNoJugable(SistemaDeVida sistemaDeVida) : base(sistemaDeVida)
    {
        
    }

    void Start()
    {
        
        sistemaDeVida.ValorActual = sistemaDeVida.ValorMax;
        barraVida.value = sistemaDeVida.ValorActual;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.value = sistemaDeVida.ValorActual;

        if(barraVida.value == sistemaDeVida.ValorMin){
            muelto();
        }
    }

    private void muelto(){
        Destroy(gameObject);
    }
}
