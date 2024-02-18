using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Nécessaire pour utiliser IEnumerator et les coroutines

public class LoadScene : MonoBehaviour
{
    // Utilisez cette méthode pour changer de scène par nom après un délai
    public void LoadSceneUsingName()
    {
        string sceneName = TabletManager.selectedPlanet;
        StartCoroutine(LoadSceneAfterDelay(sceneName)); // Lance la coroutine
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(5); // Attendre le délai
        SceneManager.LoadScene(sceneName); // Charge la scène
    }

    void ReloadCurrentScene(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
