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

    private void OnEnable()
    {
        Multiplier.Value = _minMultiplier;
    }

    public void AddScore(int score)
    {
        TotalScore.Value = Mathf.Max(TotalScore.Value+(score*Multiplier.Value),0);
        Multiplier.Value = Mathf.Min(Multiplier.Value + 1, _maxMultiplier);
        ScoreChangeEvent();
        MultiplierChangeEvent();
    }

    public void LoseCoin()
    {
        Multiplier.Value = _minMultiplier;
        MultiplierChangeEvent();
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
