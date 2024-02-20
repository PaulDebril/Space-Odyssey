using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    private Screens screens;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Trouver le script Screens dans l'un des GameObjects de la scène
        screens = FindObjectOfType<Screens>();
    }

    public void LoadSceneUsingName()
    {
        string sceneName = TabletManager.selectedPlanet + "View";
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        // Assurez-vous que l'écran affiche le compte à rebours avant de commencer le fondu.
        if (screens != null)
        {
            // Afficher le compte à rebours ici si nécessaire
            screens.ShowTimer();
        }

        // Attendre 5 secondes avant de continuer
        yield return new WaitForSeconds(5);

        // Vérifiez si l'objet Hyp est affecté et cachez-le si c'est le cas
        if (screens != null && screens.Hyp != null)
        {
            GameObjectDisplayController displayController = screens.Hyp.GetComponent<GameObjectDisplayController>();
            if (displayController != null)
            {
                displayController.HideObject();
            }
        }

        // Chargez la nouvelle scène après que l'objet Hyp a été caché
        SceneManager.LoadScene(sceneName);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
