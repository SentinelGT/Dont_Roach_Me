using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        // initialize the rigid body for the enemy
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the sprite
        if (IsFacingRight() == true)
        {
            // move right
            enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
        } else {
            //move left
            enemyRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
        
    }

    // when colider exits another collider it willexecute function
    private void OnTriggerExit2D(Collider2D collision)
    {
        // turn around
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), transform.localScale.y);      //see documentation for 'Math.f' flips everything
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
