using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{
    [SerializeField] private GameObject bot;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Sensor")
        {
            bot.GetComponent<Bot>().LeftSensor=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Sensor")
        {
            bot.GetComponent<Bot>().LeftSensor=false;
        }
    }
}
