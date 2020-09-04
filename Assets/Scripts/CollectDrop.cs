using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _points;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.AddScore(_points);
            GameObject.Destroy(collision.otherCollider.gameObject);
        }
    }   
}
