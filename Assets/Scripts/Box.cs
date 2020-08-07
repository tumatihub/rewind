using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TapeGround"))
        {
            BoxDestroy();
        }
    }

    private void BoxDestroy()
    {
        Destroy(gameObject);
    }
}
