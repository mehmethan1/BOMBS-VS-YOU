using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        score = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();

    }


    void SetScore()
    {
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log(score);

            if (score > PlayerPrefs.GetInt("BestScore", 0))
            {
                PlayerPrefs.SetInt("BestScore", score);
                bestScoreText.text = score.ToString();
            }

            SetScore();
        }
    }
   
}
