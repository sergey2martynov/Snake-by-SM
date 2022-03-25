using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    [SerializeField] private SnakeMover _snakeMover;

    private int _score = 0;

    private void Start()
    {
        _snakeMover.FruitEaten += ScorePoint;
    }

    private void ScorePoint()
    {
        _score += 1;
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}