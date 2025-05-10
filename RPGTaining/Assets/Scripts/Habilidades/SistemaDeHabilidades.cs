using System.Collections.Generic;
using UnityEngine;

public class SistemaDeHabilidades : MonoBehaviour
{
    [SerializeField] private List<Habilidad> habilidades;

    public SistemaDeHabilidades(List<Habilidad> habilidades)
    {
        this.habilidades = new List<Habilidad>();
    }

    
}
