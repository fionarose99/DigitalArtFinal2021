using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D rb;
    public GameObject player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");//or whatever the name of your player object is.
        if (transform.position.z < player.transform.position.x)
        {
            projectileSpeed = projectileSpeed * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.forward * Time.deltaTime * projectileSpeed;
        transform.Translate(projectileSpeed * Time.deltaTime, 0, 0);

    }

    public void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            anim.SetTrigger("HitChar");
        }
    }

}