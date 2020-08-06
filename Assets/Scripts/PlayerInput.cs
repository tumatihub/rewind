using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public BoolVariable IsRewinding;
    private bool _pressingJump;
    public bool PressingJump => _pressingJump;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            IsRewinding.Value = true;
        }

        if (Input.GetButtonUp("Rewind"))
        {
            IsRewinding.Value = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _pressingJump = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            _pressingJump = false;
            _playerMovement.StopJumping();
        }
    }
}
