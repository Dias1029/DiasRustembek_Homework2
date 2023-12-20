using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private PlayerController playerController;
    PlayerData playerData;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerController);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(playerData.index);
        LoadPlayer();
        Debug.Log("Scene loaded successfully!");
    }
}
