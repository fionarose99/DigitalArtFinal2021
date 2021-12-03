using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject player;
    public float walkSpeed;
    public float distanceToPlayer;
    public float chargeRange;
    public float attackRange;
    public bool walking;
    public float nextAttackPause;
    public float nextAttackPauseReset;
    public bool waiting;
    public bool isProjectile;
    public GameObject projectile;
    public BoxCollider2D headCollider;
    // Start is called before the first frame update
    void Start()
    {

        nextAttackPauseReset = nextAttackPause;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < chargeRange)
        {
            walking = true;
            if (player.transform.position.x < transform.position.x)//if the player is to the left of the enemy, enemy walk left
            {
                walkSpeed = Mathf.Abs(walkSpeed) * -1;
            }
            else
            {
                walkSpeed = Mathf.Abs(walkSpeed) * 1;
            }
        }

        else
        {
            walking = false;
            walkSpeed = Mathf.Abs(walkSpeed);
        }

        //if walking is true, we walk
        if (walking == true)
        {
            transform.Translate(walkSpeed * Time.deltaTime, 0, 0);
            //make your walking animation start
        }
        else
        {
            //make your walking animation stop

        }

        if (distanceToPlayer < attackRange)
        {
            if (waiting == false)
            {
                Attack();
                waiting = true;
                walkSpeed = 0;
            }
        }

        if (waiting == true)
        {
            nextAttackPause -= Time.deltaTime;
            if (nextAttackPause < 0)
            {
                waiting = false;
                nextAttackPause = nextAttackPauseReset;
            }
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Feet") || other.CompareTag("PlayerProj"))
        {
            Die();
        }
    }

    public void Attack()
    {
        if (isProjectile == true)
        {
            //if(wai)
            Instantiate(projectile, transform.position, Quaternion.identity);
            //trigger your throw projectile animation here
            Debug.Log("projectile thrown");
            //Debug.Break();
        }
        else
        {
            //trigger your melee animation here
            Debug.Log("melee thrown");
            //Debug.Break();

        }
    }

    public void Die()
    {
        walkSpeed = 0;
        //play death animation here.
    }
}