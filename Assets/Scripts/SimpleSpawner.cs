using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefabToSpawn;
    public float xMin = -1.2f;
    public float xMax = 1.2f;
    public float delay = 3f;
    private float _cooldown;

    void Update()
    {
        if (_cooldown <= 0)
        {
            var xPos = Random.Range(xMin, xMax);
            var obj = Instantiate(_prefabToSpawn, new Vector2(xPos, transform.position.y), Quaternion.identity);
            _cooldown = delay;
        }
        else
        {
            _cooldown -= Time.deltaTime;
        }
    }
}
