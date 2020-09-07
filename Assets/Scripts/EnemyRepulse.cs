using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRepulse : MonoBehaviour
{
    [SerializeField] private float _repulsePower;
    [SerializeField] private int _removeScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.AddScore(_removeScore);

            float xRepulse = player.transform.position.x > gameObject.transform.position.x ? 1 : -1;
            
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(xRepulse * _repulsePower, _repulsePower), ForceMode2D.Impulse);
        }
    }
}
