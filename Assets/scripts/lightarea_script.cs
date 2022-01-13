using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightarea_script : MonoBehaviour
{
    [SerializeField] private int damage = 20;


    private void OnTriggerStay2D(Collider2D collider)//do damage when staying in light
    {
        if(collider.GetComponent<Health>()!= null && collider.CompareTag("Enemy"))
        {
            Health health = collider.GetComponent<Health>();
            health.ContinuousDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)//reset timer
    {
        if(collider.GetComponent<Health>()!= null)
        {
            Health cooldowntimer = collider.GetComponent<Health>();
            cooldowntimer.resettimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)//reset timer
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health cooldowntimer = collider.GetComponent<Health>();
            cooldowntimer.resettimer();
        }
    }
}
