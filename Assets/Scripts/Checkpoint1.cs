using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bot;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player" && player.GetComponent<CarControl>().Checkpoint0==true)
        {
            player.GetComponent<CarControl>().Checkpoint1=true;
        }
        if(other.tag=="Bot" && player.GetComponent<CarControl>().Checkpoint0==true)
        {
            player.GetComponent<Bot>().Checkpoint1=true;
            Debug.Log("aaa");
        }
    }
}
