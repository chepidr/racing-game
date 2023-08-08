using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float currentSpeed;

    private Rigidbody carRb;
    private AudioSource carAS;

    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private float currentPitch;

    private void Start()
    {
        carAS=GetComponent<AudioSource>();
        carRb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Engine();
    }

    private void Engine()
    {
        currentSpeed=carRb.velocity.magnitude;
        currentPitch=carRb.velocity.magnitude/50f;
        
        if(currentSpeed<minSpeed)
        {
            carAS.pitch=minPitch;
        }

        if(currentSpeed>minSpeed )
        {
            carAS.pitch=minPitch+currentPitch;
        }

        
        
    } 

}
