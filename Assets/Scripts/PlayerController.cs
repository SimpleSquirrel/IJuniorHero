using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private bool isGrounded;

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
            _spriteRenderer.flipX = true;
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", _speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", _speed * Time.deltaTime);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _rb2d.AddForce(new Vector2(0,_jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            isGrounded = false;
        }
    }
}
