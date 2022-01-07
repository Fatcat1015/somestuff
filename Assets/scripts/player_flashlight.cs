using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_flashlight : MonoBehaviour
{
    private GameObject lightarea = default;

    private bool flashlight = false;
    //[SerializeField] private float timeTolight = 1f;
    //private float lighttimer = 0;
    private Vector3 mouse_pos;
    public Transform target;
    private Vector3 object_pos;
    private float angle;

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
            Distract();
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

        mouse_pos = Input.mousePosition;
        mouse_pos.z = -20;
        object_pos = gameObject.GetComponent<Rigidbody2D>().position;
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-30);

        //somehow this works i copied from some random website idk how it works tho

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
    }
}
