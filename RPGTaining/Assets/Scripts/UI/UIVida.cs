using UnityEngine;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    [SerializeField] private Image barraVida;

    public void ActualizarUIVida(float valorActual, float valorMaximo){
        barraVida.fillAmount = valorActual / valorMaximo;
    } 
}
