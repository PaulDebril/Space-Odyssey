using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadSceneUsingName()
    {
        string sceneName = TabletManager.selectedPlanet + "View";
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
