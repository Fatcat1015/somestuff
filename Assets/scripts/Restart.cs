using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string restartinglevel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(restartinglevel, LoadSceneMode.Single);
    }
}
