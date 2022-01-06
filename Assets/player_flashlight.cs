using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_flashlight : MonoBehaviour
{
    private GameObject lightarea = default;

    private bool flashlight = false;
    //[SerializeField] private float timeTolight = 1f;
    //private float lighttimer = 0;

    void Start()
    {
        lightarea = transform.GetChild(0).gameObject;//get child as area
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//determine if light
        {
            Light();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Deactivate_Light();
        }

        //timer function
        /*if(flashlight)//timer
        {
            lighttimer += Time.deltaTime;
        }

        if(lighttimer >= timeTolight)//reset timer
        {
            lighttimer = 0;
            flashlight = false;
            lightarea.SetActive(flashlight);
        }*/
    }

    void Light()//light function
    {
        flashlight = true;
        lightarea.SetActive(flashlight);
    }

    void Deactivate_Light()//disable light funciton
    {
        flashlight = false;
        lightarea.SetActive(flashlight);
    }
}
