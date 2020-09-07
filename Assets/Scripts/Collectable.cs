using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDrop : MonoBehaviour
{
    [SerializeField] private int _points;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.AddScore(_points);
            Destroy(gameObject);
        }
    }
}
