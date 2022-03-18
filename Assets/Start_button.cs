using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_button : MonoBehaviour
{
    public string levelname;
    private bool fade;
    public GameObject screen;
    private float alphanum = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        if (levelname != null) StartCoroutine(screenfade());
        fade = true;
    }

    private void FixedUpdate()
    {
        if (fade)
        {
            SpriteRenderer[] sprites = screen.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].color = new Color(1, 1, 1, alphanum / 100);
            }
            alphanum -= 1;
        }
    }

    IEnumerator screenfade()
    {
        yield return new WaitForSeconds(1);
        loaddascene();
    }
    void loaddascene()
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Single);
    }
}
