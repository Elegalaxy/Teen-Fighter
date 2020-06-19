using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public static bool isBgm = false;
    public GameObject PauseMenuUI;
    public int menuScene = 0;
    void Update()
    {
        if(gameObject.GetComponent<VicMenu>().vic == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GamePause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void LoadMenu()
    {
        isBgm = true;
        SceneManager.LoadScene(menuScene);
    }

    public void Exit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
