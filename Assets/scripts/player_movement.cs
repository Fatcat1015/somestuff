using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;

    public bool dead = false;

    public Animator pc_animator;

    //Animation anim;

    public bool light_on = false;
    public GameObject lightarea;

    public Transform deadscreen;

    void Start()
    {
        //anim = GetComponent<Animation>();
        pc_animator = GetComponent<Animator>();
    }

    void Update()
    {

        //if light is on
        light_on = lightarea.activeSelf;

        if (!dead)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            gameObject.GetComponent<Rigidbody2D>().MovePosition(deadscreen.position);
        }
        else
        {
            transform.position = deadscreen.position;
        }

        //character moving animation
        if(movement.x != 0 || movement.y != 0)//if moving, play animation
        {
            //pc_animator.enabled = true;
            pc_animator.speed = 0.5f;
            pc_animator.SetBool("idle", false);
            
            
            if(movement.x == 0)
            {
                pc_animator.SetInteger("left", 0);
                if (movement.y <= 0)
                {
                    pc_animator.SetInteger("up", -1);
                }
                else
                {
                    pc_animator.SetInteger("up", 1);
                }
            }
            else if (movement.x <= 0)
            {
                pc_animator.SetInteger("left", 1);
                pc_animator.SetInteger("up", 0);
            }
            else
            {
                pc_animator.SetInteger("left", -1);
                pc_animator.SetInteger("up", 0);
            }
        }
        else
        {
            pc_animator.SetBool("idle", true);
            pc_animator.SetInteger("left", 0);
            pc_animator.SetInteger("up", 0);
            //pc_animator.enabled = false;
        }

    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //move player
    }


}
