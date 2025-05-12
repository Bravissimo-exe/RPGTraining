using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador
{
    

<<<<<<< Updated upstream
    [SerializeField] private Slider barraVida;

    public PortadorNoJugable(SistemaDeVida sistemaDeVida) : base(sistemaDeVida)
    {
        
    }

    void Start()
    {
        
        
    }
=======
    
>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        // barraVida.value = sistemaDeVida.ValorActual;

        // if(barraVida.value == sistemaDeVida.ValorMin){
        //     muelto();
        // }
>>>>>>> Stashed changes
    }

    private void muelto(){
        Destroy(gameObject);
    }
}
