using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    public static GameManager instance = new GameManager();

    private void OnEnable()
    {
        controller.Dead += PlayerDead;
    }

    private void OnDisable()
    {
        controller.Dead -= PlayerDead;
    }

    void PlayerDead()
    {
        loseWindow.SetActive(true);
        controller.enabled = false;
    }

    public void Completed()
    {
        winWindow.SetActive(true);
        controller.enabled = false;
    }

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
