using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlanetDataReader : MonoBehaviour
{
    public TextAsset planetData;
    public TMP_Text planetTitle;
    public TMP_Text planetInfo;
    private Planets parsedPlanetData;
    private string activePlanetOnTablet = "";

    // Start is called before the first frame update
    void Start()
    {
        parsedPlanetData = JsonUtility.FromJson<Planets>(planetData.text);
        SetPlanetText("presentation");
    }

    void Update()
    {
        if (activePlanetOnTablet == SceneManager.GetActiveScene().name.Replace("View", "").ToLower()) return;
        SetPlanetText("presentation");
    }

    public Planet GetActivePlanetData()
    {
        string activePlanet = SceneManager.GetActiveScene().name.Replace("View", "").ToLower();
        activePlanetOnTablet = activePlanet;

        switch (activePlanet)
        {
            case "soleil":
                return parsedPlanetData.soleil;
            case "mercure":
                return parsedPlanetData.mercure;
            case "venus":
                return parsedPlanetData.venus;
            case "terre":
                return parsedPlanetData.terre;
            case "mars":
                return parsedPlanetData.mars;
            case "jupiter":
                return parsedPlanetData.jupiter;
            case "saturne":
                return parsedPlanetData.saturne;
            case "uranus":
                return parsedPlanetData.uranus;
            case "neptune":
                return parsedPlanetData.neptune;
            case "pluton":
                return parsedPlanetData.pluton;
            case "ceres":
                return parsedPlanetData.ceres;
            case "europe":
                return parsedPlanetData.europe;
            case "lune":
                return parsedPlanetData.lune;
            case "nainerouge":
                return parsedPlanetData.nainerouge;
            case "naineblanche":
                return parsedPlanetData.naineblanche;
            case "geantebleue":
                return parsedPlanetData.geantebleue;
            case "systemesolaire":
                return parsedPlanetData.systemesolaire;
            case "trounoir":
                return parsedPlanetData.trounoir;
            default:
                return new Planet();
        }
    }

    public void SetPlanetText(string textType)
    {
        Planet planetData = GetActivePlanetData();
        switch (textType)
        {
            case "presentation":
                planetTitle.text = "Presentation";
                planetInfo.text = planetData.presentation;
                break;
            case "decouverte":
                planetTitle.text = "Discoveries";
                planetInfo.text = planetData.decouverte;
                break;
            case "geographie":
                planetTitle.text = "Geography";
                planetInfo.text = planetData.geographie;
                break;
            case "mission":
                planetTitle.text = "Mission";
                planetInfo.text = planetData.mission;
                break;
            default:
                planetTitle.text = "Presentation";
                planetInfo.text = planetData.presentation;
                break;
        }
    }
}
