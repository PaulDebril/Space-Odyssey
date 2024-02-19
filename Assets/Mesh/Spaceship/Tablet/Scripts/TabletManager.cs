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
    public static string selectedPlanet;

    void Start()
    {
        index = 0;
        setActivePlanet();
    }

    IEnumerator changePlanetDelay(bool isNext = true)
    {
        yield return new WaitForSeconds(0.667f);
        setActivePlanet(isNext);
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
        if (isAnimating(planetsUi[index].GetComponent<Animator>())) return;
        getPlanetOut(planetsUi[index].gameObject, true);
        index = (index + 1) % planetsUi.Length;
        StartCoroutine(changePlanetDelay(true));
    }

    public void Previous()
    {
        if (isAnimating(planetsUi[index].GetComponent<Animator>())) return;
        getPlanetOut(planetsUi[index].gameObject, false);
        index = index - 1 >= 0 ? index - 1 : planetsUi.Length - 1;
        StartCoroutine(changePlanetDelay(false));
    }

    private bool isAnimating(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}