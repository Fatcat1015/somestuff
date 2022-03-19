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

    private bool face_left = true;
    private bool face_right = false;

    private Animator ani;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Setenemyvalue();
        setwander_destination();
        gameObject.name = "Self";
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (!seeking_player)//wander
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(direction.x, direction.y, 0), speed * Time.deltaTime);
            ani.SetBool("attack", false);
        }
        else
        {
            seekplayer();
            ani.SetBool("attack", true);
        }
    }

    private void Update()
    {
        if (0 < direction.x && direction.x >=1)
        {
            face_left = true;
            if (face_right)
            {
                face_right = false;
                Flip();
            }
        }
        if (0 > direction.x && direction.x <= -1)
        {
            face_right = true;
            if (face_left)
            {
                face_left = false;
                Flip();
            }
        }
    }

    void Flip()
    {
        gameObject.transform.Rotate(0, 180, 0, Space.Self);
    }

    private void Setenemyvalue()//set health and etc
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    public void seekplayer()//go towards the player
    {
        direction.x = player.transform.position.x - transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed * Time.deltaTime);

    }

    private IEnumerator wander()
    {
        yield return new WaitForSeconds(3f);
        direction = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        setwander_destination();
    }

    public void setwander_destination()
    {
        float rn = Random.Range(3, 10);
        if (rn < 1.5) direction = Vector2.down;
        else if (rn < 3) direction = Vector2.up;
        else if (rn < 7) direction = Vector2.left;
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
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("map"))//colliding with tilemap
        {
            StopAllCoroutines();
            direction = new Vector2(-direction.x, -direction.y);
            StartCoroutine(wander());
        }
    }
}
