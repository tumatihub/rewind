using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreValue;
    public IntegerVariable TotalScore;

    private void OnEnable()
    {
        _scoreValue.text = TotalScore.Value.ToString();    
    }
}
