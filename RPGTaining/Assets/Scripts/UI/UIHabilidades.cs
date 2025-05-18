using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHabilidades : MonoBehaviour
{
    [System.Serializable]
    public class HabilidadUI
    {
        public GameObject bloqueo;
        public TextMeshProUGUI textoCooldown;
    }

    [SerializeField] private Image imageHabilidad1;
    [SerializeField] private Image imageHabilidad2;
    [SerializeField] private Image imageHabilidad3;

    [Header("UI de habilidades")]
    public HabilidadUI[] habilidades = new HabilidadUI[3];

    public void ActualizarEstadoHabilidad(int index, bool disponible, float cooldownRestante)
    {
        if (index < 0 || index >= habilidades.Length) return;

        habilidades[index].bloqueo.SetActive(!disponible);

        if (!disponible)
        {
            habilidades[index].textoCooldown.gameObject.SetActive(true);
            habilidades[index].textoCooldown.text = Mathf.CeilToInt(cooldownRestante).ToString();
        }
        else
        {
            habilidades[index].textoCooldown.gameObject.SetActive(false);
        }
    }

    public void AsignarIconos(Sprite icono1, Sprite icono2, Sprite icono3)
    {
        imageHabilidad1.sprite = icono1;
        imageHabilidad2.sprite = icono2;
        imageHabilidad3.sprite = icono3;
    }
}
