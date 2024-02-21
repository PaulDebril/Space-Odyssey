using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialText;

    private int tutorialStep = 0;

    public string[] tutorialMessages = {
        "Pour commencer, choisssez une planète à visiter depuis la tablette.",
        "Appuyez sur le bouton rouge pour confirmer votre choix.",
        "Actionnez le levier pour envoyer le vaisseau vers la planète choisie.",
        "Rendez-vous sur le pupitre au fond du vaisseau pour en apprendre plus sur la planète visitée."
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
