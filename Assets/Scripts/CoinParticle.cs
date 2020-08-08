using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticle : MonoBehaviour
{
    public FloatVariable CoinPitch;
    private AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (CoinPitch != null)
        {
            _audioSource.pitch = CoinPitch.Value;
        }
        _audioSource.PlayOneShot(_audioClip);
    }
}
