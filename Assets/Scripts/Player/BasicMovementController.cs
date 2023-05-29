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

    void Start()
    {
        _anim= GetComponentInChildren<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
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
    }
}
