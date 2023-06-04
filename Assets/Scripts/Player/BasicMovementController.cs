using Nati.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour
{
    [SerializeField]
    float _MovementSpeed = 10f;

    Rigidbody2D _rig;
    SpriteRenderer _renderer;
    float _direction = 0;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        /*
         _direction = Input.GetAxis("Horizontal);
        if (_direction != 0)
        {
            GameEvents.SetAnimationBool?.Invoke("IsRunning", true);
            _renderer.flipX = _direction > 0 ? false : true;
            Vector2 movementDirection = new Vector2(_direction * _MovementSpeed, 0);
            _rig.AddForce(movementDirection);
        }
        else
        {
          GameEvents.SetAnimationBool?.Invoke("IsRunning", false);
        }
        */

        if (TouchInputController.GetAxis(Axis.Horizontal) != 0)
        {
            _direction = TouchInputController.GetAxis(Axis.Horizontal);
            GameEvents.SetAnimationBool?.Invoke("IsRunning", true);
            _renderer.flipX = _direction > 0 ? false : true;
            Vector2 movementDirection = new Vector2(_direction * _MovementSpeed, 0);
            _rig.AddForce(movementDirection);
        }
        else
        {
            GameEvents.SetAnimationBool?.Invoke("IsRunning", false);

        }

    }

    public void MoveDirection(float direction)
    {
        _direction = direction;
    }
}
