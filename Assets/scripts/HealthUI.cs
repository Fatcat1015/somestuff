using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private GameObject player;
    private Health PHealth;
    public Sprite emptyheart;
    public Sprite fullheart;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PHealth = player.GetComponent<Health>();
    }

    private void Update()
    {
        Image[] images = GetComponentsInChildren<Image>();

        
        for (int i = PHealth.health; i < images.Length; i++)
        {
            images[i].sprite = emptyheart;

        }

        if (PHealth.health <= 5)
        {
            for (int i = 0; i < PHealth.health; i++)
            {
                images[i].sprite = fullheart;

            }
        }
    }
}
