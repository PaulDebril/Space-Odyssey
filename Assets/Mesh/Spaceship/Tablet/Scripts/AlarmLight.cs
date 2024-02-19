using System.Collections;
using System.Collections.Generic; // Nécessaire pour utiliser les listes
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public List<Light> spotLights; // Liste pour stocker les références des Spot Lights

    public GameObject spotLightsObject; // Référence à l'objet Spot Lights
    private Material spotLightsMaterial; // Référence au matériau de l'objet Spot Lights

    void Start()
    {
        // Récupérer le matériau de l'objet Spot Lights
        spotLightsMaterial = spotLightsObject.GetComponent<Renderer>().material;
    }

    public void StartChangingColor()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        // Comptez 10 changements de couleur (10 secondes)
        for (int i = 0; i < 12; i++)
        {
            foreach (Light spotLight in spotLights) // Boucle à travers toutes les Spot Lights
            {
                // Change la couleur entre rouge et blanc pour chaque Spot Light
                spotLight.color = (spotLight.color == Color.red) ? Color.white : Color.red;
            }

            // Change également la couleur du matériau de l'objet Spot Lights
            if (spotLightsMaterial != null)
            {
                Color currentColor = spotLightsMaterial.GetColor("_EmissionColor");
                Color newColor = (currentColor == Color.red) ? Color.white : Color.red;
                spotLightsMaterial.SetColor("_EmissionColor", newColor);
            }

            // Attend 1 seconde avant le prochain changement
            yield return new WaitForSeconds(0.8f);
        }
    }
}
