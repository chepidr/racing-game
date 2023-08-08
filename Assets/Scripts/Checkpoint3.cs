using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bot;
    [SerializeField] private GameObject endGame;
    [SerializeField] private GameObject speedometer;
    [SerializeField] private GameObject camera;
    private AudioListener carAL;

    private void Start()
    {
        carAL=camera.GetComponent<AudioListener>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player" && player.GetComponent<CarControl>().Checkpoint2==true)
        {
            endGame.SetActive(true);
            speedometer.SetActive(false);
            Time.timeScale=0f;
            carAL.enabled=false;
        }
        if(other.tag=="Bot" && bot.GetComponent<CarControl>().Checkpoint2==true)
        {
            endGame.SetActive(true);
            speedometer.SetActive(false);
            Time.timeScale=0f;
            carAL.enabled=false;
            Debug.Log("aaa");
        }
    }
}
