using UnityEngine;

public class SpaceshipPersistence : MonoBehaviour
{
    public GameObject objectToPersist; // Vous pouvez assigner cet objet depuis l'éditeur Unity

    void Awake()
    {
        if (objectToPersist != null) // Vérifiez que l'objet à persister n'est pas null
        {
            DontDestroyOnLoad(objectToPersist);
            Debug.Log(objectToPersist);
        }
        else
        {
            // Si aucun objet n'est assigné, ne détruisez pas l'objet actuel
            DontDestroyOnLoad(gameObject);

        }
    }
}
