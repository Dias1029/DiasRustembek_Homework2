using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

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
}
