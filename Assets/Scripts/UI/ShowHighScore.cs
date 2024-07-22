using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private HighScoreContainer _highScore;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        _text.text = _highScore.HighScore.ToString();
    }
}
