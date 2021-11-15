using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you presss right arrow, run to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(runSpeed, 0, 0);
        }

        //if ypu press left arrow, run left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-runSpeed, 0, 0);
        }

        //if you press space, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpStrength;
        }


    }
}
