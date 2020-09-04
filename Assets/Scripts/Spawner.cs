using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _drop;
    [SerializeField] private float _cooldown;
    [SerializeField] private bool _singleElement;

    private float _cooldownLeft;

    private void Update()
    {
        _cooldownLeft += Time.deltaTime;
        if (_cooldownLeft >= _cooldown)
        {
            _cooldownLeft = 0;

            SpawnElement();
        }
    }

    private void SpawnElement()
    {
        var drop = Instantiate(_drop, gameObject.transform.position, Quaternion.identity);
        drop.transform.SetParent(gameObject.transform);
    }
}
