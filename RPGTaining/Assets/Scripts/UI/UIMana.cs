using UnityEngine;
using UnityEngine.UI;

public class UIMana : MonoBehaviour
{
    [SerializeField] private Image barraMana;

    public void ActualizarMana(float valorActual, float valorMaximo){
        barraMana.fillAmount = valorActual / valorMaximo;
    } 
}
