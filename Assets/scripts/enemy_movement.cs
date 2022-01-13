using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5;

    [SerializeField] private enemydata data;

    private GameObject player;

    private Vector2 random_pos;
    private Vector2 destination;

    public bool seeking_player = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Setenemyvalue();

    }

    private void FixedUpdate()
    {
        if (!seeking_player)//wander
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            seekplayer();
        }

        if (Vector2.Distance(transform.position, destination) <= speed - 0.0001)//arrives at destination
        {
            StartCoroutine(wander());
        }
    }

    private void Setenemyvalue()//set health and etc
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    public void seekplayer()//go towards the player
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public IEnumerator wander()
    {
        yield return new WaitForSeconds(1);
        random_pos.x = transform.position.x + Random.Range(-10.0f, 10.0f);
        random_pos.y = transform.position.y + Random.Range(-10.0f, 10.0f);
        destination = random_pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//colliding with player
        {
            Debug.Log("damage");
            player.GetComponent<Health>().Damage(damage);
        }
    }
}
