using UnityEngine;

public class SpaceshipSpawnManager : MonoBehaviour
{
    private void Start()
    {
        // Trouvez le point de spawn dans la scène par son nom
        GameObject spawnPoint = GameObject.Find("spawnPoint");
        
        // Si le point de spawn est trouvé, déplacez le vaisseau à cette position
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            // Si aucun point de spawn n'est trouvé, affichez un message d'erreur
            Debug.LogError("Spawn point not found in the scene! Make sure there is a GameObject named 'spawnPoint'.");
        }
    }
}
