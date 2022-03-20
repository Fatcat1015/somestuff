using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] public int health = 5;
    public int Max_health = 5;//max health
    public int h_left = 5;
    private float cooldowntimer = 0f;
    [SerializeField] private float cooldown = 1f;
    private bool invincible = false;

    public GameObject loot_heal;
    public GameObject loot_bomb;

    void Update()
    {
        if (health <= 0)//die
        {
            Die();
        }

        h_left = health;
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
        if (!invincible)
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
        invincible = true;
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = color;
            
        }
        yield return new WaitForSeconds(cooldown);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = Color.white;
        }
        invincible = false;

    }

    private void Die()//die
    {
        if (gameObject.CompareTag("Player"))
        {
            FindObjectOfType<player_movement>().dead = true;
        }
        else
        {
            var loot = Random.Range(0, 3);
            if (loot < 1.5)
            {
                Instantiate(loot_heal, transform.position,transform.rotation);
            }
            else
            {
                Instantiate(loot_bomb, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        
    }

    public void resettimer()//reset cool down timer
    {
        cooldowntimer = 0;
    }

}
