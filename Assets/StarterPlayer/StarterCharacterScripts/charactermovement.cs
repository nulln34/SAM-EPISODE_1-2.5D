using System;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    
    public float speed = 5f;
    Rigidbody rb;
    GameObject player;
    Camera cam;

    SpriteRenderer spriteRenderer;
    
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
 
    }


    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.linearVelocity = new Vector3(-movement.x * speed, movement.y * speed, -movement.z * speed);
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z + 7);

        if(movement.magnitude < 0.1f)
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                animator.Play("idle");
            }
            
        }
        else if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("sidewalk"))
            {
                animator.Play("sidewalk");
            }
        }
        else if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("sidewalk"))
            {
                animator.Play("sidewalk");
            }
        }
        else if(movement.z < 0)
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("forwards"))
            {
                animator.Play("forwards");
            }
        }
        else if(movement.z > 0)
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("backwards"))
            {
                animator.Play("backwards");
            }
        }

        

       
    }
}
