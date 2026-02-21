using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Country
{
    public string name;
    public long population;
    public float minLat;
    public float maxLat;
    public float minLng;
    public float maxLng;
}

[System.Serializable]
public class CountryDatabase
{
    public Country[] countries;
}