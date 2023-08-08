using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
    private int map;
    void Start()
    {
        map=1;
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name=="Drift Track")
        {
            SceneManager.LoadScene("Menu");
        }

        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name=="Sprint Track")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void SelectDriftTrack()
    {
        map=1;
    }

    public void SelectSprintTrack()
    {
        map=2;
    }

    public void GoToGame()
    {
        if(map==1)
        {
            SceneManager.LoadScene("Drift Track");
        }
        else if(map==2)
        {
            SceneManager.LoadScene("Sprint Track");
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
