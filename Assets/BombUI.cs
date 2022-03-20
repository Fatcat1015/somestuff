using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombUI : MonoBehaviour
{
    private GameObject player;
    private player_flashlight Bombcount;
    public Sprite empty;
    public Sprite full;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Bombcount = player.GetComponentInChildren<player_flashlight>();
    }

    private void Update()
    {
        Image[] images = GetComponentsInChildren<Image>();


        for (int i = Bombcount.bombCount; i < images.Length; i++)
        {
            images[i].sprite = empty;

        }

        if (Bombcount.bombCount <= 3)
        {
            for (int i = 0; i < Bombcount.bombCount; i++)
            {
                images[i].sprite = full;

            }
        }
    }
}
