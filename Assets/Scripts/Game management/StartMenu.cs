using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private int levelIndex;

    public void StartGame()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
