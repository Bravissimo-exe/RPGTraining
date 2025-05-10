using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaDeHabilidades : MonoBehaviour
{
    private List<Habilidad> habilidades;

    public SistemaDeHabilidades(){
        habilidades = new List<Habilidad>();
    }

    public List<Habilidad> Habilidades { 
        get {
            if(habilidades == null)
                habilidades = new List<Habilidad>();
            return habilidades;
        }
        set => habilidades = value;
    }

    public void AñadirHabilidad(Habilidad habilidad){
        Habilidades.Add(habilidad);
    }
}
