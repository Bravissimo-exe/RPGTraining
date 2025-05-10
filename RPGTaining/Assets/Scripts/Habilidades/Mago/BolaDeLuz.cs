using System.Collections;
using UnityEngine;

public class BolaDeLuz : Habilidad
{
    private int nivelCarga = 0;
    private int cargaMaxima = 3;
    private float tiempoPorCarga = 1f;
    private Coroutine rutinaCarga;
    private MonoBehaviour controladorMono;


    public BolaDeLuz(string nombre, Sprite icono, string descripcion, float consumo, float coolDown) : base(nombre, icono, descripcion, consumo, coolDown)
    {
    }

    private IEnumerator Cargar(){
        nivelCarga = 0;
        while(nivelCarga < cargaMaxima){
            yield return new WaitForSeconds(tiempoPorCarga);
            nivelCarga++;
            Debug.Log("Carga Actual: " + nivelCarga);//Reemplazar por verlo en UI
        }
    }

    public void EmpezarCarga(MonoBehaviour mono){
        controladorMono = mono;
        rutinaCarga = mono.StartCoroutine(Cargar());
    }

    public void SoltarCarga(){

        if (rutinaCarga != null)
        {
            // Cancela la carga si aún está en progreso
            // (si no es qué simplemente ya terminó)
            controladorMono.StopCoroutine(rutinaCarga);
        }

        Lanzar();
    }

    public override void Lanzar()
    {
        switch (nivelCarga)
        {
            case 1:
                //Instanciar Carga 1
                //Instantiate(GameObject, Tra)
                break;
            case 2:
                //Instanciar Carga 2
                break;
            case 3:
                //Instanciar Carga 3
                break;
        }
        nivelCarga = 0;
    }
}
