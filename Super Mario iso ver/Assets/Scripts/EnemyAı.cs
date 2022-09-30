using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAı : MonoBehaviour
{

    public Transform groundCheckPos;
    public float walkSpeed = 5f;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;


    public BoxCollider2D collider1;
    private Animator _animator;
    private BoxCollider2D[] _colliders;

    public Rigidbody2D rb;
    public LayerMask groundLayer;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _colliders = GetComponents<BoxCollider2D>();
        mustPatrol = true;
        collider1 = GetComponents<BoxCollider2D>()[0];
    }

    public void Kill()
    {
        _animator.Play("enemy_death");
       
        Destroy(gameObject);
    }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
