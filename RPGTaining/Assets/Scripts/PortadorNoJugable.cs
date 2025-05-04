using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PortadorNoJugable : Portador
{

    [SerializeField] private GameObject portadorNoJugable;
    [SerializeField] private GameObject prefab;
    

    private float _tiempoReaparicion = 3f;
    private float _tiempoDestruccion = 0f;

    private bool _vivo = true;
    public PortadorNoJugable(SistemaDeVida sistemaVida) : base(sistemaVida)
    {
        sistemaVida.ValorMax = 100;
        sistemaVida.ValorMin = 0;
    }

    void Start()
    {

    }

    void Update()
    {
        if(!_vivo){
            _tiempoDestruccion += Time.deltaTime;
            if(_tiempoDestruccion >= _tiempoReaparicion){
                Instantiate(gameObject, transform.position, Quaternion.identity);

                sistemaVida.ValorActual = sistemaVida.ValorMax;
                _vivo = true;
            }
        }   
    }

    public void Reaparecer(){
        
    }


    public void Destruir(){
        if(sistemaVida.ValorActual <= sistemaVida.ValorMin){
            Destroy(portadorNoJugable);
            _vivo = false;
        }
    }  
}
