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
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void muelto(){
        Destroy(gameObject);
    }
}
