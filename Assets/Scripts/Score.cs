using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Score : ScriptableObject
{
    public IntegerVariable TotalScore;

    private UnityAction ScoreChangeEvent;

    public void AddScore(int score)
    {
        TotalScore.Value = Mathf.Max(TotalScore.Value+score,0);
        ScoreChangeEvent();
    }

    public void Subscribe(UnityAction action)
    {
        ScoreChangeEvent += action;
    }

    public void Unsubscribe(UnityAction action)
    {
        ScoreChangeEvent -= action;
    }

}
