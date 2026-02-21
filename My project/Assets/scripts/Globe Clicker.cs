using UnityEngine;

public class GlobeClicker : MonoBehaviour
{
    public GameObject Earth;
    public CountryInfoPanel InfoPanel;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        // Make sure we hit the Earth
        if (hit.collider.gameObject != Earth &&
            hit.collider.transform.parent?.gameObject != Earth) return;

        // Convert hit point to local position on unit sphere
        Vector3 localPoint = Earth.transform.InverseTransformPoint(hit.point).normalized;

        // Convert to lat/lng
        float lat = Mathf.Asin(localPoint.y) * Mathf.Rad2Deg;
        float lng = Mathf.Atan2(localPoint.z, localPoint.x) * Mathf.Rad2Deg;

        CountryLookup lookup = Earth.GetComponent<CountryLookup>();
        if (lookup == null) return;

        Country country = lookup.GetCountryAtLatLng(lat, lng);
        InfoPanel.Show(country, lat, lng);
    }
}