using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused=false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject speedometer;
    [SerializeField] private GameObject camera;
    private AudioListener carAL;

    void Start()
    {
        carAL=camera.GetComponent<AudioListener>();
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        speedometer.SetActive(true);
        Time.timeScale=1f;
        GameIsPaused=false;
        carAL.enabled=true;
    }

    public void Paused()
    {
        pauseMenu.SetActive(true);
        speedometer.SetActive(false);
        Time.timeScale=0f;
        GameIsPaused=true;
        carAL.enabled=false;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
