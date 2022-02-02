using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class explosion : MonoBehaviour
{
    public Light2D explo_l;
    private float life_timer = 3f;
    private float timer = 0;
    private float acc_intensity = 0.5f;
    private float max_intensity = 1f;

    void Start()
    {
        explo_l.intensity = 0;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(explo_l.intensity >= max_intensity)explo_l.intensity = max_intensity;
        else explo_l.intensity += acc_intensity * Time.deltaTime;

        if (timer >= life_timer) Destroy(gameObject);
    }
}
