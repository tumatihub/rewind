using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public IntegerVariable TotalScore;
    public IntegerVariable Multiplier;

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _multiplierText;
    [SerializeField] Score _score;

    private void OnEnable()
    {
        _score.SubscribeScoreUI(UpdateScoreUI);
        _score.SubscribeMultiplierUI(UpdateMultiplierUI);
    }

    private void Start()
    {
        TotalScore.Value = 0;    
    }

    public void UpdateScoreUI()
    {
        _scoreText.text = TotalScore.Value.ToString();
    }

    public void UpdateMultiplierUI()
    {
        _multiplierText.text = "x" + Multiplier.Value.ToString();
    }

    private void OnDisable()
    {
        _score.UnsubscribeScoreUI(UpdateScoreUI);
        _score.UnsubscribeMultiplierUI(UpdateMultiplierUI);
    }
}
