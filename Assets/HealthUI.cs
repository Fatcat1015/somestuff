using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private GameObject player;
    private Health PHealth;
    private RectTransform rt;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PHealth = player.GetComponent<Health>();
        rt = GetComponent<RectTransform>();

    }

    private void Update()
    {
        rt.sizeDelta = new Vector2(PHealth.h_left * 250, 15);
    }
}
