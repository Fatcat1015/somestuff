using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_level : MonoBehaviour
{
    public string levelname;
    private bool fade;
    private float alphanum = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelname != null && collision.CompareTag("Player") )
        { 
            StartCoroutine(screenfade());
            fade = true;
        }
    }

    private IEnumerator screenfade()
    {
        yield return new WaitForSeconds(1);
        loaddascene();
    }

    void loaddascene()
    {
        if(levelname!= null)SceneManager.LoadScene(levelname, LoadSceneMode.Single);
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alphanum/100);
        if (fade) alphanum += 1;
    }
}
