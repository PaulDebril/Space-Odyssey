using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Screens : MonoBehaviour
{
    public TMP_Text leftScreen;
    public TMP_Text rightScreen;
    public GameObject Hyp;
    private ScreenType displayType;
    private float countdown;
    private string planetName = "";


    private LoadScene sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = gameObject.AddComponent(typeof(LoadScene)) as LoadScene;  
    }

    public void ShowTimer()
    {
        if (displayType == ScreenType.Timer || planetName == "") {
            return;
        };
        
        countdown = 10;
        leftScreen.fontSize = 80;
        rightScreen.fontSize = 80;
        displayType = ScreenType.Timer;
    }

    public void ShowActivePlanet()
    {
        leftScreen.fontSize = 30;
        rightScreen.fontSize = 30;
        planetName = TabletManager.selectedPlanet;
        displayType = ScreenType.Text;
    }

    public void DisableScreen()
    {
        displayType = ScreenType.None;
    }

    void Update()
    {
        if (displayType == ScreenType.None) {
            leftScreen.text = "";
            rightScreen.text = "";
            return;
        } else if (displayType == ScreenType.Text) {
            leftScreen.text = "Choix: " + planetName;
            rightScreen.text = "Choix: " + planetName;
            return;
        };

        if (countdown>0){
            countdown-=Time.deltaTime;
        } else {
            Hyp.GetComponent<GameObjectDisplayController>().ShowObject();
            Hyp.GetComponent<TestMove>().StartMovementCycle();
            sceneLoader.LoadSceneUsingName();
            displayType = ScreenType.None;
        }

        double b=System.Math.Round(countdown,2);

        leftScreen.text = b.ToString();
        rightScreen.text = b.ToString();
    }
}

public enum ScreenType {
    None,
    Timer,
    Text
};