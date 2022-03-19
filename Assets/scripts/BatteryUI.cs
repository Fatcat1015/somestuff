using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    private GameObject flashlight;
    private player_flashlight pf;
    private RectTransform rt;
    private void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("Flash");
        pf = flashlight.GetComponent<player_flashlight>();
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.sizeDelta = new Vector2(pf.timeleft * 250, 42);
        //sprites color
        if (!pf.flashlight) gameObject.GetComponent<Image>().color = Color.red;
        else gameObject.GetComponent<Image>().color = Color.white;
    }
}
