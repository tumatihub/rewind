using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Box : MonoBehaviour
{
    public FloatVariable Speed;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y - (Speed.Value * Time.fixedDeltaTime)));
    }

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
