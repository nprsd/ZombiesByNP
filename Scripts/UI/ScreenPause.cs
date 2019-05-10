using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ScreenPause : MonoBehaviour
{
    public GameObject isPaused;
    public static bool GameisPaused = false;
    public static bool exitable = false;

    void Update () {

        if (Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

    void Resume()
    {
        isPaused.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        exitable = false;
    }

    void Pause()
    {
        isPaused.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        exitable = true;
    }
}
