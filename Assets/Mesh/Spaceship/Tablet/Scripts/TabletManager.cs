using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletManager : MonoBehaviour
{
    public GameObject[] planetsUi;
    public GameObject[] planetsModels;
    public TMP_Text planetText;
    int index;
    private bool isAnimating = false;
    public static string selectedPlanet;

    void Start()
    {
        index = 0;
        setActivePlanet();
    }

    IEnumerator changePlanetDelay(bool isNext = true)
    {
        yield return new WaitForSeconds(0.667f);
        planetsUi[index].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        setActivePlanet(isNext);
        yield return new WaitForSeconds(0.667f);
        planetsUi[index].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        isAnimating = false;
    }

    private void setActivePlanet(bool isNext = true)
    {
        for (int i = 0; i < planetsUi.Length; i++)
        {
            planetsUi[i].gameObject.SetActive(i == index);
            planetsModels[i].gameObject.SetActive(i == index);
        }
        
        getPlanetIn(planetsUi[index].gameObject, isNext);
        TabletManager.selectedPlanet = planetsUi[index].gameObject.name;
        planetText.text = PlanetNameFormat.formatPlanetName(TabletManager.selectedPlanet);
    }

    private void getPlanetOut(GameObject planet, bool isNext)
    {
        planet.GetComponent<Animator>().SetTrigger(!isNext ? "exitNext" : "exitPrevious");
    }

    private void getPlanetIn(GameObject planet, bool isNext)
    {
        planet.GetComponent<Animator>().SetTrigger(!isNext ? "enterNext" : "enterPrevious");
    }

    public void Next()
    {
        if (isAnimating) return;
        isAnimating = true;
        getPlanetOut(planetsUi[index].gameObject, true);
        index = (index + 1) % planetsUi.Length;
        StartCoroutine(changePlanetDelay(true));
    }

    public void Previous()
    {
        if (isAnimating) return;
        isAnimating = true;
        getPlanetOut(planetsUi[index].gameObject, false);
        index = index - 1 >= 0 ? index - 1 : planetsUi.Length - 1;
        StartCoroutine(changePlanetDelay(false));
    }
}