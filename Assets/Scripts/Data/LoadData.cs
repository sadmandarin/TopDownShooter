using UnityEngine;

public class LoadData : MonoBehaviour
{
    public HighScoreContainer maxScoreData;

    private void Awake()
    {
        maxScoreData.SetHighScore(SaveManager.LoadMaxScore());
    }
}
