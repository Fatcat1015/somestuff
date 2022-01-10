using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5;

    [SerializeField] private enemydata data;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Setenemyvalue();
    }

    void Update()
    {
        //idle: choose a random destination, wanders there

        //attack: when detecting the player's light, move towards player
        seekplayer();

        //hit: when under the influence of the light, slow down
    }

    private void Setenemyvalue()//set health and etc
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void seekplayer()//go towards the player
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)//damage player
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Health>().Damage(damage);
            this.GetComponent<Health>().Damage(1000);
        }
    }
}
