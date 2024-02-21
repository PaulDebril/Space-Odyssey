using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialText;

    private int tutorialStep = 0;

    public string[] tutorialMessages = {
        "Firstly, choose a planet to visit on the tablet.",
        "Press the red button to confirm your choice.",
        "Press the lever to send the ship to the chosen planet.",
        "Go to the desk at the back of the ship to learn more about the planet you're visiting."
    };

    // Start is called before the first frame update
    void Start()
    {
        tutorialText.text = tutorialMessages[tutorialStep];
    }

    public void SetStep(int step)
    {
        if (step != tutorialStep + 1) return;
        if (step >= tutorialMessages.Length) return;

        tutorialStep = step;
        tutorialText.text = tutorialMessages[step];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
