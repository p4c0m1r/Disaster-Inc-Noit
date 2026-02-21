using UnityEngine;
using UnityEngine.UI;

public class CountryInfoPanel : MonoBehaviour
{
    public GameObject Panel;
    public Text CountryNameText;
    public Text PopulationText;
    public Text CoordinatesText;
    public Button CloseButton;

    void Start()
    {
        Panel.SetActive(false);
        CloseButton.onClick.AddListener(() => Panel.SetActive(false));
    }

    public void Show(Country country, float lat, float lng)
    {
        Panel.SetActive(true);

        if (country != null)
        {
            CountryNameText.text = country.name;
            PopulationText.text = "Population: " + country.population.ToString("N0");
        }
        else
        {
            CountryNameText.text = "Unknown";
            PopulationText.text = "No data available";
        }

        CoordinatesText.text = $"Lat: {lat:F1}°  Lng: {lng:F1}°";
    }
}