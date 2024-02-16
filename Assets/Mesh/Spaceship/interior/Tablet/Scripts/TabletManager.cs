using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletManager : MonoBehaviour
{
    public GameObject[] planetsUi;
    public GameObject[] planetsModels;
    int index;

    void Start()
    {
        index = 0;
        setActivePlanet();
    }

    private void setActivePlanet(bool isNext = true)
    {
        getPlanetIn(planetsUi[index].gameObject, isNext);

        for (int i = 0; i < planetsUi.Length; i++)
        {
            planetsUi[i].gameObject.SetActive(i == index);
            planetsModels[i].gameObject.SetActive(i == index);
        }
    }

    private void getPlanetOut(GameObject planet, bool isNext)
    {
        planet.GetComponent<Animator>().SetTrigger(isNext ? "exitNext" : "exitPrevious");
    }

    private void getPlanetIn(GameObject planet, bool isNext)
    {
        planet.GetComponent<Animator>().SetTrigger(isNext ? "enterNext" : "enterPrevious");
    }

    public void Next()
    {
        getPlanetOut(planetsUi[index].gameObject, true);
        index = (index + 1) % planetsUi.Length;
        setActivePlanet();
    }

    public void Previous()
    {
        getPlanetOut(planetsUi[index].gameObject, false);
        index = index - 1 >= 0 ? index - 1 : planetsUi.Length - 1;
        setActivePlanet();
    }
}