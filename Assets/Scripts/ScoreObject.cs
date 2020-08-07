using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] private Score _score;
    public IntegerVariable ObjectScore;
    [SerializeField] private GameObject _particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _score.AddScore(ObjectScore.Value);
            if (_particles != null)
            {
                Instantiate(_particles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

    }
}
