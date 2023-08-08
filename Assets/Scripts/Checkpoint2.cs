using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bot;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player" && player.GetComponent<CarControl>().Checkpoint1==true)
        {
            player.GetComponent<CarControl>().Checkpoint2=true;
        }
        if(other.tag=="Bot" && bot.GetComponent<CarControl>().Checkpoint1==true)
        {
            bot.GetComponent<Bot>().Checkpoint2=true;
            Debug.Log("aaa");
        }
    }
}
