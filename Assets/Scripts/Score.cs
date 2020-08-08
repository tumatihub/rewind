using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Score : ScriptableObject
{
    public IntegerVariable TotalScore;
    public IntegerVariable Multiplier;

    [SerializeField] private int _maxMultiplier = 10;
    [SerializeField] private int _minMultiplier = 1;

    private UnityAction ScoreChangeEvent;
    private UnityAction MultiplierChangeEvent;

    [SerializeField] private ScoreUnit _scoreUnity;

    private void OnEnable()
    {
        Multiplier.Value = _minMultiplier;
    }

    public void AddScore(int score)
    {
        TotalScore.Value = Mathf.Max(TotalScore.Value+(score*Multiplier.Value),0);
        ScoreChangeEvent();
        if (Multiplier.Value < _maxMultiplier)
        {
            Multiplier.Value++;
            MultiplierChangeEvent();
        }
    }

    public void LoseCoin()
    {
        Multiplier.Value = _minMultiplier;
        MultiplierChangeEvent();
    }

    public void SpawnScoreUnit(Vector3 position, int score)
    {
        var obj = Instantiate(_scoreUnity, position, Quaternion.identity);
        obj.UpdateScore(score * Multiplier.Value);
    }

    public void SubscribeScoreUI(UnityAction action)
    {
        ScoreChangeEvent += action;
    }

    public void UnsubscribeScoreUI(UnityAction action)
    {
        ScoreChangeEvent -= action;
    }

    public void SubscribeMultiplierUI(UnityAction action)
    {
        MultiplierChangeEvent += action;
    }

    public void UnsubscribeMultiplierUI(UnityAction action)
    {
        MultiplierChangeEvent -= action;
    }

}
