using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriterenderer;

    public int maxHealth = 100;
    public int currentHealth;
    public HeathBar healthBar;
    public GameObject _Player;
    public Transform respawnPoint;


    [SerializeField]
    private float runSpeed = 7f;
    [SerializeField]
    private float jumpSpeed = 5f;

    bool IsGrounded;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckA;
    [SerializeField]
    Transform groundCheckB;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider == collision.gameObject.GetComponent<EnemyAı>().collider1)

            {
                TakeDamage(20);
            }
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            _Player.transform.position = respawnPoint.position;
            currentHealth += 100;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<EnemyAı>();
            enemy.Kill();
        }
    }




    private void FixedUpdate()
    {
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground2"))) ||
         (Physics2D.Linecast(transform.position, groundCheckA.position, 1 << LayerMask.NameToLayer("ground2"))) ||
         (Physics2D.Linecast(transform.position, groundCheckB.position, 1 << LayerMask.NameToLayer("ground2"))))       
        {
            IsGrounded = true;

        }
        else
        {
            IsGrounded = false;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if (IsGrounded)
                animator.Play("run");
            spriterenderer.flipX = false; 
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            if (IsGrounded)
                animator.Play("run");
            spriterenderer.flipX = true;
        }
        else
        {
            if (IsGrounded)
                animator.Play("defult_state2");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


        if ((Input.GetKey("space") || Input.GetKey("w")) && IsGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("jump");
        }
    }
}
