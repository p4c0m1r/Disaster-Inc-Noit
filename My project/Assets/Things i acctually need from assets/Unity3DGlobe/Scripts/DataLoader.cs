using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {
    public DataVisualizer Visualizer;

    void Start()
    {
        TextAsset jsonData = Resources.Load<TextAsset>("population");
        if (jsonData == null)
        {
            Debug.LogError("DataLoader: Could not find 'population.json' in a Resources folder!");
            return;
        }
        string json = jsonData.text;
        SeriesArray data = JsonUtility.FromJson<SeriesArray>(json);
        if (data == null || data.AllData == null || data.AllData.Length == 0)
        {
            Debug.LogError("DataLoader: JSON parsed but AllData is empty. Check your JSON structure.");
            return;
        }
        Visualizer.CreateMeshes(data.AllData);
    }

    void Update() { }
}

[System.Serializable]
public class SeriesArray
{
    public SeriesData[] AllData;
}