using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public BoolVariable IsRewinding;
    private Animator _anim;

    void Start()
    {
        IsRewinding.Value = false;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("IsRewinding", IsRewinding.Value);
    }
}
