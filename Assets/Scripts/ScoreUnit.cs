using TMPro;
using UnityEngine;

public class ScoreUnit : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreValue;
    [SerializeField] private float _moveDist = 1f;
    [SerializeField] private float _moveDelay = 1f;
    [SerializeField] private float _alphaValue = .5f;
    [SerializeField] private float _alphaDelay = 1f;
    void Start()
    {
        LeanTween.move(gameObject, transform.position + (Vector3.up * _moveDist), _moveDelay);
        //LeanTween.alphaText(_scoreValue.GetComponent<RectTransform>(), _alphaValue, _alphaDelay);
        Destroy(gameObject, Mathf.Max(_moveDelay, _alphaDelay));
    }

    public void UpdateScore(int score)
    {
        _scoreValue.text = score.ToString();
    }
}
