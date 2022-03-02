using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{

    public float spawn_interval = 3;
    public GameObject enemy;
    private float timer = 0;

    void FixedUpdate()
    {
        if(timer < spawn_interval){
            timer += Time.deltaTime;
        }
        else{
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
    }

}
