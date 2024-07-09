using System.IO;
using UnityEngine;
using script;

public class GameManager : MonoBehaviour
{
    private JsonData jsonData;
    private DataManager _dataManager;

    private void Awake()
    {
        _dataManager = FindObjectOfType<DataManager>(); // Find the DataManager component in the scene
        Debug.Log(Application.dataPath);
        string saveDataPath = Application.dataPath + "/SaveData.json";

        // Check if the file exists
        if (!File.Exists(saveDataPath)) // If the file does not exist
        {
            // Create new JsonData and save it
            _dataManager.SetEditJson(new JsonData(86, 7, "김동훈"));
        }

        // Load the JsonData
        jsonData = _dataManager.LoadJson();

        // Print the loaded data to debug
        Debug.Log("name: " + jsonData.Name);
        Debug.Log("hp: " + jsonData.Hp);
        Debug.Log("level: " + jsonData.Level);
    }

    void Start()
    {
        // Your start logic here
    }

    void Update()
    {
        
    }
}