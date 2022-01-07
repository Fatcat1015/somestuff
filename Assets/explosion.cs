using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Light explo_l;
    private float life_timer = 1.25f;
    private float timer = 0;
    private float acc_range = 1f;
    private float max_range = 1f;

    void Start()
    {
        explo_l.range = 0;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(explo_l.range >= max_range)explo_l.range = max_range;
        else explo_l.range += acc_range * Time.deltaTime;

        if (timer >= life_timer) Destroy(gameObject);
    }
}
