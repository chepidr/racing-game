using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint0 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bot;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            player.GetComponent<CarControl>().Checkpoint0=true;
            Debug.Log("aaa");
        }
        if(other.tag=="Bot")
        {
            bot.GetComponent<Bot>().Checkpoint0=true;
            Debug.Log("aaa");
        }
    }
}
