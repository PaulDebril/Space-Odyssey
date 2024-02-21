using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Content.Interaction;

public class Screens : MonoBehaviour
{
    public TMP_Text leftScreen;
    public TMP_Text rightScreen;
    public GameObject Hyp;
    public GameObject lever;
    public Transform handle;
    public GameObject fadeScreen;
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
        lever.GetComponent<XRLever>().enabled = false;
    }

    public void ShowActivePlanet()
    {
        leftScreen.fontSize = 30;
        rightScreen.fontSize = 30;
        planetName = PlanetNameFormat.formatPlanetName(TabletManager.selectedPlanet);
        displayType = ScreenType.Text;
    }

    public void DisableScreen()
    {
        displayType = ScreenType.None;
    }

    void Update()
    {
        if (displayType == ScreenType.None) {
            leftScreen.fontSize = 30;
            rightScreen.fontSize = 30;
            leftScreen.text = "Choose a planet...";
            rightScreen.text = "Choose a planet...";
            return;
        } else if (displayType == ScreenType.Text) {
            leftScreen.text = "Choice: " + planetName;
            rightScreen.text = "Choice: " + planetName;
            return;
        };

        if (countdown>0){
            countdown-=Time.deltaTime;
        } else {
            Hyp.GetComponent<GameObjectDisplayController>().ShowObject();
            sceneLoader.LoadSceneUsingName(lever, handle, fadeScreen);
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