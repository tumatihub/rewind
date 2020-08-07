using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] ParticleSystem _boxParticles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TapeGround"))
        {
            BoxDestroy();
        }
    }

    private void BoxDestroy()
    {
        Instantiate(_boxParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
