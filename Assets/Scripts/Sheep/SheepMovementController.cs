using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SheepMovementController : MonoBehaviour
{
    [SerializeField]
    float _XSpeed = 2.5f;
    [SerializeField]
    float _YSpeed = 10f;

    Rigidbody2D _rig;
    SpriteRenderer _spriteRenderer;
    [SerializeField]
    float _movementDirection = 1;

    void Start()
    {
        _rig= GetComponent<Rigidbody2D>();
        _spriteRenderer= GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        transform.position += new Vector3(_XSpeed * _movementDirection * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
            if (playerHealth.IsAlive)
                playerHealth.PlayerDeath();
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            _rig.velocity = new Vector2(0,_YSpeed);
        }
        else
        {
            _movementDirection = ((transform.position - collision.transform.position).normalized.x) > 0 ? 1 : -1; ;
            _rig.velocity = new Vector2(0, _YSpeed/2);
            _spriteRenderer.flipX = _movementDirection > 0 ? false: true;

        }
    }

    public void SetDirection(float direction)
    {
        _movementDirection = direction;
    }

   
}
