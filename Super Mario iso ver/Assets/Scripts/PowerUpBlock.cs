using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpBlock : MonoBehaviour
{
    [SerializeField]
    private Sprite _inactiveSprite;


    [SerializeField]
    private GameObject _powerUp;

    private bool _used;


    private void OnCollisionEnter2D(Collision2D other)
    {
        var Player = other.collider.GetComponent<player>();
        if (!_used && Player != null && other.contacts[0].normal.y > 0)
        {
            GetComponent<SpriteRenderer>().sprite = _inactiveSprite;
            Instantiate(_powerUp, transform.position, Quaternion.identity);
            _used = true;
        }

    }








}

