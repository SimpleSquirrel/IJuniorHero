using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private bool isPlayerGrounded;

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
            MovePlayer(_speed, "left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(_speed, "right");
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && isPlayerGrounded)
        {
            _rb2d.AddForce(new Vector2(0,_jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            isPlayerGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            isPlayerGrounded = false;
        }
    }

    private void MovePlayer(float _speed, string direction)
    {
        bool swapDirection = direction.Equals("right");

        
        _animator.SetFloat("Speed", _speed * Time.deltaTime);
        _spriteRenderer.flipX = !swapDirection;

        _speed = swapDirection ? _speed : -_speed;
        transform.Translate(_speed * Time.deltaTime, 0, 0);        
    }
}
