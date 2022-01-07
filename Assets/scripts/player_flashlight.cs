using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_flashlight : MonoBehaviour
{
    private GameObject lightarea = default;

    private bool flashlight = false;
    //[SerializeField] private float timeTolight = 1f;
    //private float lighttimer = 0;
    private bool distract_cd = false;
    public GameObject projectile;
    public Transform spawnpoint;

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

        if(Input.GetKeyDown(KeyCode.E))//throw distraction
        {
            if(distract_cd != true)
            {
                distract_cd = true;
                Distract();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))//throw distraction
        {
            distract_cd = false;
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

        //mouse rotation functions:

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

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

    void Distract()
    {
        //spawn a projectile that emits light when struck the ground
        Instantiate(projectile, spawnpoint.position, spawnpoint.rotation);
    }
}
