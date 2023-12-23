using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    #endregion

    #region Private Variables

    private bool _grounded, _gameStarted, _jumping;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    #endregion

    #endregion

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_gameStarted)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }
        if (_jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            _jumping = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_gameStarted && _grounded)
            {
                _animator.SetTrigger("Jump");
                _jumping = true;
                _grounded = false;
            }
            else
            {
                _gameStarted = true;
                _animator.SetBool("GameStarted", _gameStarted);
            }
        }
        _animator.SetBool("Grounded", _grounded);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }
    }
}
