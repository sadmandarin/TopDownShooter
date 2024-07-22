using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _newRecord;
    [SerializeField] private HighScoreContainer _container;

    private Text _text;

    private void OnEnable()
    {
        _text = GetComponent<Text>();
        _text.text = _score.Scores.ToString();

        if (_score.Scores > _container.HighScore)
        {
            _newRecord.SetActive(true);
            _container.SetHighScore(_score.Scores);
            SaveManager.SaveMaxScore(_score.Scores);
        }

    }
}
