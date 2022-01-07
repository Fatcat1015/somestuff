using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_fire : MonoBehaviour
{
    [SerializeField] public float pforce = 200f;
    public Rigidbody2D rb;
    private float dragforce = 0.75f;
    private float exlode_timer = 1f;
    private float timer = 0f;

    public GameObject explosion;
    public Transform spawn_ex;

    void Start()
    {
        //add force
        GetComponent<Rigidbody2D>().AddForce(transform.up * pforce);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        rb.drag += dragforce * Time.deltaTime;

        if(timer >= exlode_timer)
        {
            Explode();
        }
    }

    void Explode()//exploding functions
    {
        rb.mass = 10;
        Debug.Log("explo");
        Instantiate(explosion, spawn_ex.position, spawn_ex.rotation);
        Destroy(gameObject);
    }
}
