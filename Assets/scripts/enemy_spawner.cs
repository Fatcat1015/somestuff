using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]

public class enemy_spawner : MonoBehaviour
{

    public float spawn_interval = 3;
    public GameObject enemy;
    private float timer = 0;

    public int spawn_num = 10;
    public bool spawning;

    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void FixedUpdate()
    {
        if (spawning)
        {
            if (timer < spawn_interval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(enemy, transform.position, transform.rotation);
                spawn_num -= 1;
                timer = 0;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))spawning = true;
    }
}
