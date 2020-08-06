using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform _groundCollider;
    private bool _isGrounded;
    private bool _isJumping;
    private PlayerInput _playerInput;
    [SerializeField] private float _pressingJumpLimit = 1f;
    private float _pressingJumpDuration = 0;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _horizontalSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Jump();
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (_isGrounded)
        {
            if (_playerInput.IsRewinding.Value)
            {
                ChangeHorizontalSpeed(-_horizontalSpeed);
            }
            else
            {
                ChangeHorizontalSpeed(_horizontalSpeed);
            }
        }
    }

    private void Jump()
    {
        if (_playerInput.PressingJump && !_isJumping && _isGrounded) { 
            _isJumping = true;
            _pressingJumpDuration = 0;
        }

        if (_playerInput.PressingJump && _isJumping && _pressingJumpDuration < _pressingJumpLimit)
        {
            ChangeVerticalSpeed(_jumpSpeed);
            _pressingJumpDuration += Time.deltaTime;
        }
    }

    public void StopJumping()
    {
        _isJumping = false;
        _pressingJumpDuration = 0;
    }

    public void ChangeVerticalSpeed(float speed)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, speed);
    }

    public void ChangeHorizontalSpeed(float speed)
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TapeGround"))
        {
            _isGrounded = true;
            _isJumping = false;
            _pressingJumpDuration = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TapeGround"))
        {
            _isGrounded = false;
        }
    }
}
