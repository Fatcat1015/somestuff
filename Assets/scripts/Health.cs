using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int Max_health = 100;//max health
    private float cooldowntimer = 0f;
    [SerializeField] private float cooldown = 0.5f;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Damage(int amount)//damage
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative Damage");//error
        }

        if (cooldowntimer >= cooldown)
        {
            cooldowntimer = 0;
            Debug.Log("reset in stay");
        }

        if (cooldowntimer == 0)
        {
            this.health -= amount;
        }

        cooldowntimer += Time.deltaTime;


    }

    public void Heal(int amount)//heal
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative Heal");
        }

        if (health + amount > Max_health)//if its bigger than max health
        {
            this.health = Max_health;
        }
        else
        {
            this.health += amount;
        }

    }

    private void Die()//die
    {
        Debug.Log("dead");
    }

    public void resettimer()//reset cool down timer
    {
        cooldowntimer = 0;
    }

}
