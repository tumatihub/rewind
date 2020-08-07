using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
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
}
