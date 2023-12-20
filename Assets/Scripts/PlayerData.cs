using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public float[] position;
    public SceneManager scenemanager;
    public int index = SceneManager.GetActiveScene().buildIndex;

    public PlayerData(PlayerController player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
