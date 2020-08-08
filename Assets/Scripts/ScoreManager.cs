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
    [SerializeField] private float _scoreScale = 1.2f;
    [SerializeField] private float _scoreDelay = .2f;
    [SerializeField] private float _multiplierScale = 1.2f;
    [SerializeField] private float _multiplierDelay = .2f;

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
        ScaleUI(_scoreText.GetComponent<RectTransform>(), _scoreScale, _scoreDelay);
    }

    private void ScaleUI(RectTransform rect, float scale, float delay)
    {
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(rect, new Vector3(scale, scale, 0f), delay));
        seq.append(LeanTween.scale(rect, new Vector3(1f, 1f, 0f), delay));
    }

    public void UpdateMultiplierUI()
    {
        _multiplierText.text = "x" + Multiplier.Value.ToString();
        ScaleUI(_multiplierText.GetComponent<RectTransform>(), _multiplierScale, _multiplierDelay);
    }

    private void OnDisable()
    {
        _score.UnsubscribeScoreUI(UpdateScoreUI);
        _score.UnsubscribeMultiplierUI(UpdateMultiplierUI);
    }
}
