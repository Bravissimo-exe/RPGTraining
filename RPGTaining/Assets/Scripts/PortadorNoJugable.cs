using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador
{

    [SerializeField] private Slider barraVida;

    void Start()
    {
        valorActual = valorMax;
        barraVida.value = valorActual;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.value = valorActual;

        if(barraVida.value == 0){
            muelto();
        }
    }

    private void muelto(){
        Destroy(gameObject);
    }
}
