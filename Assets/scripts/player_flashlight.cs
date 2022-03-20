using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_flashlight : MonoBehaviour
{
    private GameObject lightarea = default;

    public bool flashlight = true;
    public float timeTolight = 5f;
    public float lighttimer = 0;
    public GameObject projectile;
    public Transform spawnpoint;
    public bool activated = false;
    public float timeleft = 0;
    public int bombCount = 3;

    void Start()
    {
        lightarea = transform.GetChild(0).gameObject;//get child as area
        lightarea.SetActive(false);
    }

    void Update()
    {
        lightarea.SetActive(activated);
        timeleft = (timeTolight - lighttimer) / timeTolight;
        if (flashlight)
        {
            if (Input.GetKeyDown(KeyCode.Space))//determine if light
            {
                activated = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                activated = false;
            }
        }
        else
        {
            activated = false;
        }
        

        if(Input.GetKeyDown(KeyCode.E))//throw distraction
        {
            if(bombCount != 0)
            {
                bombCount -= 1;
                Distract();
            }
        }

        //timer function
        if(flashlight)//timer
        {
            if (activated) lighttimer += Time.deltaTime;
            else if (lighttimer <= 0) lighttimer = 0;
            else if (lighttimer > 0) lighttimer -= (6 / 5 * Time.deltaTime);
        }
        else
        {
            if (lighttimer >= 0) lighttimer -= Time.deltaTime / 2;
            else lighttimer = 0;
        }

        if(lighttimer >= timeTolight)// timer
        {
            flashlight = false;
        }

        if (lighttimer == 0) flashlight = true; 

        //mouse rotation functions:

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(  Vector3.forward, mousePos - transform.position);



    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3);
        flashlight = true;
    }

    void Distract()
    {
        //spawn a projectile that emits light when struck the ground
        Instantiate(projectile, spawnpoint.position, spawnpoint.rotation);
    }
}
