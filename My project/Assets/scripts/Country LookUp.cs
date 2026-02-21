using UnityEngine;

public class CountryLookup : MonoBehaviour
{
    private CountryDatabase database;

    void Start()
    {
        TextAsset json = Resources.Load<TextAsset>("countries");
        if (json == null)
        {
            Debug.LogError("CountryLookup: Missing Resources/countries.json!");
            return;
        }
        database = JsonUtility.FromJson<CountryDatabase>(json.text);
    }

    public Country GetCountryAtLatLng(float lat, float lng)
    {
        if (database == null) return null;

        Country best = null;
        float bestArea = float.MaxValue;

        foreach (Country c in database.countries)
        {
            if (lat >= c.minLat && lat <= c.maxLat && lng >= c.minLng && lng <= c.maxLng)
            {
                float area = (c.maxLat - c.minLat) * (c.maxLng - c.minLng);
                if (area < bestArea)
                {
                    bestArea = area;
                    best = c;
                }
            }
        }
        return best;
    }
}