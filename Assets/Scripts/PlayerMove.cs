using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private bool _grounded;

    private enum Direction
    {
        Left = -1,
        Right = 1
    }

    private Animator _animator;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(_speed, (int)Direction.Left);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Move(_speed, (int)Direction.Right);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && _grounded)
        {
            _rb2d.AddForce(new Vector2(0,_jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            _grounded = false;
        }
    }

    private void Move(float _speed, int direction)
    {        
        _animator.SetFloat("Speed", _speed * Time.deltaTime);
        _spriteRenderer.flipX = direction == -1 ? true : false;

        transform.Translate(direction * _speed * Time.deltaTime, 0, 0);        
    }
}
