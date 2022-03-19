using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFollow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
