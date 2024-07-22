using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private Text _text;
    [SerializeField] private HighScoreContainer _highScore;

    public event Action ScoreUpdate;
    public int Scores { get { return _score; } }

    private void Start()
    {
        _text.text = _score.ToString();
    }

    private void OnEnable()
    {
        ScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        ScoreUpdate -= UpdateScore;
    }

    public void AddingScore(int score)
    {
        _score += score;
        ScoreUpdate?.Invoke();
    }

    void UpdateScore()
    {
        _text.text = _score.ToString();
    }
}
