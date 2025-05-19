using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke(nameof(RestartLevel), 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(LevelComplete), 1f);
        }
    }
    private void LevelComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            SceneManager.LoadScene(0); 
        }
        else { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
