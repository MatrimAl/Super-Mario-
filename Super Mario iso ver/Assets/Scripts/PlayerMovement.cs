using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _playerRb;

    [Header("Attributes")]
    public float moveSpeed;
    public float jumpHeight;
    public float dragMultiplier;

    [Header("Set In Inspector")] 
    public Animator playerAnimator;
    
    [Header("Booleans")]
    public bool isGrounded;
    public bool isLookingRight = true;

    private void Start()
    {
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerRb.AddForce(Vector2.left * (moveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerRb.AddForce(Vector2.right * (moveSpeed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, 0f);
            _playerRb.AddForce(Vector2.up * jumpHeight);
            isGrounded = false;
        }
        
        playerAnimator.SetFloat("VerticalSpeed",Mathf.Abs(_playerRb.velocity.x));
        playerAnimator.SetBool("IsGrounded",isGrounded);
        playerAnimator.SetFloat("HorizontalSpeed",_playerRb.velocity.y);
        
    }

    private void FixedUpdate()
    {
        // Fake drag
        var velocity = _playerRb.velocity;
        velocity = new Vector2(velocity.x * dragMultiplier,velocity.y);
        _playerRb.velocity = velocity;
    }
}
