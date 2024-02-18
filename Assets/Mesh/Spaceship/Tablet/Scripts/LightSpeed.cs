using UnityEngine;

public class GameObjectDisplayController : MonoBehaviour
{
    public GameObject objectToDisplay; // GameObject à afficher, assigné dans l'inspecteur ou par code

    // Start is called before the first frame update
    void Start()
    {
        // Cache le GameObject par défaut
        if (objectToDisplay != null)
        {
            objectToDisplay.SetActive(false);
        }
    }

    // Active l'affichage du GameObject
    public void ShowObject()
    {
        if (objectToDisplay != null)
        {
            objectToDisplay.SetActive(true);
        }
    }

    // Désactive l'affichage du GameObject
    public void HideObject()
    {
        if (objectToDisplay != null)
        {
            objectToDisplay.SetActive(false);
        }
    }
}
