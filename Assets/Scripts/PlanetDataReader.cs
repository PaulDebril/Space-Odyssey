using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetDataReader : MonoBehaviour
{
    public TextAsset planetData;
    private Planets parsedPlanetData;

    // Start is called before the first frame update
    void Start()
    {
        parsedPlanetData = JsonUtility.FromJson<Planets>(planetData.text);
    }

    public Planet GetActivePlanetData()
    {
        string activePlanet = SceneManager.GetActiveScene().name.replace("View", "");
        
        switch (activePlanet) {
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
                throw new Exception("Planet not found");
        }
    }
}
