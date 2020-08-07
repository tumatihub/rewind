﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] private Score _score;
    public IntegerVariable ObjectScore;
    [SerializeField] private ParticleSystem _scoreParticles;
    [SerializeField] private ParticleSystem _lostCoin;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _score.AddScore(ObjectScore.Value);
            if (_scoreParticles != null)
            {
                Instantiate(_scoreParticles, transform.position, Quaternion.identity);
            }
        }

        if (collision.gameObject.CompareTag("TapeGround"))
        {
            Instantiate(_lostCoin, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
