using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }
}