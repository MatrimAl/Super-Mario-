using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PowerUpFlower : MonoBehaviour
{
    [SerializeField]
    private Vector2 _initialVelocity;


    [SerializeField]
    private float _reenableColliderAfter;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _rigidbody.velocity = _initialVelocity;
        _collider.enabled = false;
        
        StartCoroutine(ReeanbleCollider());
    }
    private IEnumerator ReeanbleCollider()
    {
        yield return new WaitForSeconds(_reenableColliderAfter);
        _collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var Player = other.collider.GetComponent<player>();
        if (Player != null)
        {
            Destroy(gameObject);
        }
    }
}
