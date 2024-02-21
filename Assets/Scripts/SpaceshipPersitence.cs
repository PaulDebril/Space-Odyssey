using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipPersistence : MonoBehaviour
{
    public GameObject objectToPersist;
    void Awake()
    {
        if (objectToPersist != null) // Vérifiez que l'objet à persister n'est pas null
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name != "1 Start Scene") // Vérifie si la scène n'est pas la scène d'index 0
            {
                DontDestroyOnLoad(objectToPersist);
                Debug.Log(objectToPersist);
            }
            else
            {
                // Si la scène est la scène d'index 0, détruire l'objet persistant
                Destroy(objectToPersist);
            }
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
