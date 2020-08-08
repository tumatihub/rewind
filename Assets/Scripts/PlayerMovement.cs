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
    [SerializeField] private float _horizontalSpeed = 2f;
    [SerializeField] private float _jumpSpeed = 4f;
    [SerializeField] private float _jumpHorizontalSpeed = 3f;
    [SerializeField] private float _timeToPauseAfterDie = 3f;
    private bool _isDead = false;

    private Animator _anim;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _deathSFX;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (_isDead) return;

        ChangeDirection();
        Jump();
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
            _anim.SetBool("IsJumping", true);
            _audioSource.PlayOneShot(_jumpSFX);
            _pressingJumpDuration = 0;
            if (_playerInput.IsRewinding.Value)
            {
                ChangeHorizontalSpeed(-_jumpHorizontalSpeed);
            }
            else
            {
                ChangeHorizontalSpeed(_jumpHorizontalSpeed);
            }
        }

        if (_playerInput.PressingJump && _isJumping && _pressingJumpDuration < _pressingJumpLimit)
        {
            ChangeVerticalSpeed(_jumpSpeed);
            _pressingJumpDuration += Time.fixedDeltaTime;
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
            _anim.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && _isGrounded && !_isDead)
        {
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {
        _isDead = true;
        _audioSource.PlayOneShot(_deathSFX);
        GetComponent<Collider2D>().enabled = false;
        ChangeHorizontalSpeed(-1);
        ChangeVerticalSpeed(2);
        _anim.SetTrigger("Die");
        Debug.Log("GAME OVER!");

        yield return new WaitForSeconds(_timeToPauseAfterDie);
        Pause();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TapeGround"))
        {
            _isGrounded = false;
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }
}
