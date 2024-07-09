using System.IO;
using UnityEngine;
using script; // Ensure this namespace matches the namespace used in your JsonData class

public class DataManager : MonoBehaviour
{
    private string _filePath;

    private void Awake()
    {
        _filePath = Application.dataPath + "/SaveData.json";
    }

    public void SetEditJson(JsonData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_filePath, json);
    }

    public JsonData LoadJson()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonUtility.FromJson<JsonData>(json);
        }
        return null;
    }
}