using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNameFormat : MonoBehaviour
{
    public static string formatPlanetName(string planetName)
    {
        if (planetName == null) return "";

        int indexFirstMaj = PlanetNameFormat.FindFirstCap(planetName);
        string formatedPName = indexFirstMaj != -1 ? planetName.Insert(indexFirstMaj, " ") : planetName;

        return PlanetNameFormat.capitalizePlanet(formatedPName);
    }

    private static int FindFirstCap(string planetName)
    {
        for (int i = 0; i < planetName.Length; i++)
        {
            if (char.IsUpper(planetName[i]))
            {
                return i;
            }
        }

        return -1;
    }

    private static string capitalizePlanet(string planetName)
    {
        if (planetName.Length > 1)
            return char.ToUpper(planetName[0]) + planetName.Substring(1);

        return planetName.ToUpper();
    }
}
