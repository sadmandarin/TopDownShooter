using UnityEngine;

[CreateAssetMenu(fileName = "ScoreContainer", menuName = "SO/ScoreContainer", order = 1)]
public class HighScoreContainer : ScriptableObject
{
    [SerializeField] private int _highScore;

    public int HighScore { get { return _highScore; } private set { _highScore = value; } }

    public int SetHighScore(int score)
    {
        if (score > _highScore)
            return _highScore = score;

        return _highScore;
    }
}
