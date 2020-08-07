using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public IntegerVariable TotalScore;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] Score _score;

    private void OnEnable()
    {
        _score.Subscribe(UpdateScoreUI);    
    }

    private void Start()
    {
        TotalScore.Value = 0;    
    }

    public void UpdateScoreUI()
    {
        _scoreText.text = TotalScore.Value.ToString();
    }

    private void OnDisable()
    {
        _score.Unsubscribe(UpdateScoreUI);
    }
}
