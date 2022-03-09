using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5;

    [SerializeField] private enemydata data;

    private GameObject player;

    public Vector2 direction;

    public bool seeking_player = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Setenemyvalue();
        setwander_destination();
    }

    private void FixedUpdate()
    {

        if (!seeking_player)//wander
        {

            transform.Translate(direction * speed/2 * Time.deltaTime);
        }
        else
        {
            seekplayer();
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
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed * Time.deltaTime);
    }

    private IEnumerator wander()
    {
        //Debug.Log("wanderrunning");
        yield return new WaitForSeconds(3f);
        direction = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        setwander_destination();
    }

    public void setwander_destination()
    {
        //Debug.Log("wrunning");
        float rn = Random.Range(0, 10);
        if (rn < 2.5) direction = Vector2.down;
        else if (rn < 5) direction = Vector2.up;
        else if (rn < 7.5) direction = Vector2.left;
        else if (rn <= 10) direction = Vector2.right;
        StartCoroutine(wander());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//colliding with player
        {
            player.GetComponent<Health>().Damage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = new Vector2(-direction.x, -direction.y);
    }
}
