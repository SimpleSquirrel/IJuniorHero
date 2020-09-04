using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;

    public void AddScore(int points)
    {
        _score += points;
    }
}
