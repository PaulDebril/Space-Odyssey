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

    private void setActivePlanet()
    {
        for (int i = 0; i < planetsUi.Length; i++)
        {
            planetsUi[i].gameObject.SetActive(i == index);
            planetsModels[i].gameObject.SetActive(i == index);
        }
    }

    public void Next()
    {
        index = (index + 1) % planetsUi.Length;
        setActivePlanet();
    }

    public void Previous()
    {
        index = index - 1 >= 0 ? index - 1 : planetsUi.Length - 1;
        setActivePlanet();
    }
}