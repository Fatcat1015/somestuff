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
        if (health <= 0)//die
        {
            Die();
        }
    }

    public void SetHealth(int Maxhealth, int health)//set health
    {
        this.Max_health = Maxhealth;
        this.health = health;
    }

    public void ContinuousDamage(int amount)//damage
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative Damage");//error
        }

        if (cooldowntimer >= cooldown)
        {
            cooldowntimer = 0;
        }

        if (cooldowntimer == 0)
        {
            this.health -= amount;
            StartCoroutine(VisualIndicator(Color.red));
        }

        cooldowntimer += Time.deltaTime;
    }

    public void Damage(int amount)//damage
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative Damage");//error
        }
        else
        {
            this.health -= amount;
            StartCoroutine(VisualIndicator(Color.red));
        }

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
            StartCoroutine(VisualIndicator(Color.green));
        }

    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Die()//die
    {
        if (gameObject.CompareTag("Player"))
        {
            FindObjectOfType<player_movement>().dead = true;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void resettimer()//reset cool down timer
    {
        cooldowntimer = 0;
    }

}
