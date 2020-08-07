using UnityEngine;

[CreateAssetMenu]
public class Score : ScriptableObject
{
    public IntegerVariable TotalScore;

    public void AddScore(int score)
    {
        TotalScore.Value = Mathf.Max(TotalScore.Value+score,0);
    }
}
