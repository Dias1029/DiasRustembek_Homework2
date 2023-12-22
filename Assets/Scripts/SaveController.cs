using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public DataPlayer data = new DataPlayer();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Load();
        }
    }

    private void Save()
    {
        DataPlayer data = new DataPlayer(transform.position, gameObject.name);
        this.data = data;
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("JSON", json);
        string path = Path.Combine(Application.persistentDataPath, "PLAYINGDATA.json");
        Debug.Log(path);
        File.WriteAllText(path, json);
        Debug.Log("Saved! " + json);
    }

    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "PLAYINGDATA.json");
        data = JsonUtility.FromJson<DataPlayer>(File.ReadAllText(path));
        transform.position = data.Position;
        Debug.Log("Loaded old position!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            string activeScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("LevelSaved", activeScene);
            Save();

            Debug.Log(activeScene);

            gameObject.SetActive(false);
        }
    }
}

[Serializable]
public class DataPlayer
{
    public Vector3 Position;
    public string name;

    public DataPlayer() { }

    public DataPlayer(Vector3 position, string name)
    {
        Position = position;
        this.name = name;
    }
}
