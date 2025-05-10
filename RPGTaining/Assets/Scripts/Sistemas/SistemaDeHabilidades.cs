using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaDeHabilidades : MonoBehaviour
{
    [SerializeField] private List<Habilidad> habilidades;

    public SistemaDeHabilidades(){}

    

    public List<Habilidad> Habilidades { 
        get => new List<Habilidad>(habilidades);
        set => habilidades = value;
    }

    public void añadirHabilidad(Habilidad habilidad){
        List<Habilidad> listaHabilidades = Habilidades;
        listaHabilidades.Add(habilidad);
    }
}
