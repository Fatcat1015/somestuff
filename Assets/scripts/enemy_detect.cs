using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_detect : MonoBehaviour
{

    public CircleCollider2D detect_range;

    public GameObject enemy;

    public bool if_found_player = false;

    public GameObject player;

    public float aggro = 7;
    public float original = 5;

    void Start()
    {
        detect_range = GetComponent<CircleCollider2D>();
        enemy = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

        void Update()//set radius depending on the player's flashlight
        {
                if(player.GetComponent<player_movement>().light_on){
                    detect_range.radius = aggro;
                }else{
                    detect_range.radius = original;
                }
        }

    IEnumerator detect_timer()//continue go towards player
    {
        yield return new WaitForSeconds(2);
        if (!if_found_player)
        {
            enemy.GetComponent<enemy_movement>().seeking_player = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//stop approaching player
        {
            if_found_player = false;
            StartCoroutine(detect_timer());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))// approach player
        {
            if_found_player = true;
            enemy.GetComponent<enemy_movement>().seeking_player = true;
        }
    }
}
