using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //don't forget to add the BoxCollider2D to your player
    //also add a rigidbody2D
    public float walkSpeed;
    public float jumpStrength;
    Rigidbody2D rb;
    public GameObject yourProjectile;
    public bool isProjectile;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //make your walking animation start
            
            
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //make your walking animation stop

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //make your walking animation start
            //
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //make your walking animation stop

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-walkSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(walkSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpStrength;
            // if user does press-space and player is on-ground, then do jetpack-startup
            // if in-air, then do looping-jetpack-in-air
            // if in-air and just-hit-the-ground, then do jetpack-shutdown
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        }
    }
    
    public void Attack()
    {
        if(isProjectile == true)
        {
            // do open-mini-rocket-doors-on-handlebars anim THEN do instantiate rockets
            Instantiate(yourProjectile, transform.position, Quaternion.identity);
        }
        else
        {
            //call your attack animation here.

            //enable the collider2D for the attack motion

        }
    }
}
