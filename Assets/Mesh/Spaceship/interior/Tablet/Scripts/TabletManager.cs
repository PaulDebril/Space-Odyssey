using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletManager : MonoBehaviour
{
    public GameObject[] background;
    int index;

    void Start()
    {
        index = 0;
        setActivePlanet();
        Debug.Log("actvated");
    }

    private void setActivePlanet()
    {
        for (int i = 0; i < background.Length; i++)
        {
            Debug.Log(i == index);
            background[i].gameObject.SetActive(i == index);
        }
    }

    public void Next()
    {
        Debug.Log(index + 1);
        Debug.Log(background.Length);
        
        index = (index + 1) % background.Length;
        setActivePlanet();
    }

    public void Previous()
    {
        index = index - 1 >= 0 ? index - 1 : background.Length - 1;
        setActivePlanet();
    }
}