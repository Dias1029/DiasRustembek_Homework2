using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : SaveController
{
    [SerializeField] private string newGameLevel;
    void Start()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        SceneManager.LoadScene(1);

        yield return null;
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameButton()
    {
        if(PlayerPrefs.HasKey("LevelSaved"))
        {
            string levelToLoad = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelToLoad);
            Load();
        }
    }
}
