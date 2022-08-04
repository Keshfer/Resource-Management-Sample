using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {
        get; 
        private set; 
    }
    public Color TeamColor;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            
            
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        load();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void save()
    {
        SaveData data = new SaveData();
        data.TeamColor = this.TeamColor;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        //Debug.Log(Application.persistentDataPath + "/savefile.json");

    }

    public void load()
    {
        
        //path holds the location of savefile.json
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            //pathContent holds the contents of savefile.json
            string pathContent = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(pathContent);
            TeamColor = data.TeamColor;

        }
    }

}
