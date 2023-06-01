using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour
{
    [SerializeField]
    float _MovementSpeed = 10f;

    Animator _anim;
    Rigidbody2D _rig;
    SpriteRenderer _renderer;
    float _direction = 0;

    void Start()
    {
        _anim= GetComponentInChildren<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        /*
        if(Input.GetAxis("Horizontal") != 0)
        {
            _anim.SetBool("IsRunning", true);
            float direction = Input.GetAxis("Horizontal");
            _renderer.flipX = direction > 0 ? false : true;
            Vector2 movementDirection = new Vector2(direction * _MovementSpeed, 0);
            _rig.AddForce(movementDirection);
        }
        else
        {
            _anim.SetBool("IsRunning", false);

        }
        */

        if (_direction != 0)
        {
            _anim.SetBool("IsRunning", true);
            _renderer.flipX = _direction > 0 ? false : true;
            Vector2 movementDirection = new Vector2(_direction * _MovementSpeed, 0);
            _rig.AddForce(movementDirection);
        }
        else
        {
            _anim.SetBool("IsRunning", false);

        }

    }

    public void MoveLeft()
    {
        _anim.SetBool("IsRunning", true);
        float direction = -1;
        _renderer.flipX = true;
        Vector2 movementDirection = new Vector2(direction * _MovementSpeed, 0);
        _rig.AddForce(movementDirection);
    }

    public void MoveRight()
    {
        _anim.SetBool("IsRunning", true);
        float direction = 1;
        _renderer.flipX = false;
        Vector2 movementDirection = new Vector2(direction * _MovementSpeed, 0);
        _rig.AddForce(movementDirection);
    }

    public void MoveDirection(float direction)
    {
        _direction = direction;
    }
}
