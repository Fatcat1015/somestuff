using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgeaHeal : MonoBehaviour
{
    [SerializeField]private int healamount = 10;
    private bool used = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!used)
        {
            if (collision.GetComponent<Health>().health < 5)
            {
                collision.GetComponent<Health>().Heal(healamount);
                GetComponent<SpriteRenderer>().color = Color.gray;
                var children = new List<GameObject>();
                foreach (Transform child in transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));
                used = true;

            }
            
        }
    }
}
