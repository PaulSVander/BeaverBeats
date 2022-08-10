using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TMP_Text multiText;
    public TMP_Text scoreText;
    public TMP_Text streakText;
    public HealthBar healthBar;
    public RawImage background;

    public int score;
    public int scorePerNote;
    public int multi;
    public int streak = 0;
    public float alpha;

    void Start()
    {
        score = 0;
        // Set starting multiplier to 1 and set points per on time input to 20
        scorePerNote = 20;
        multi = 1;
        alpha = 0.5f;
        Invoke("SongEnd", 55.0f);
        scoreText = GetComponent<TextMeshProUGUI>();
        multiText = GameObject.FindGameObjectWithTag("MultiText").GetComponent<TextMeshProUGUI>();
        streakText = GameObject.FindGameObjectWithTag("StreakText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // Currently using Update() to test score updating functionality
    void SongEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void noteSuccess()
    {
        healthBar.GainHealth();
        // Increment current streak counter and update multiplier at each streak threshold 
        streakUpdate();
        backgroundAlphaUpdate(true);

        // Multiply the score per note by current multiplier and update score
        score += scorePerNote * multi;
        scoreText.SetText(score.ToString());
        PlayerPrefs.SetInt("score", score);
    }

    public void noteFail()
    {
        backgroundAlphaUpdate(false);
        healthBar.LoseHealth();
        streak = 0;
        streakText.SetText(0.ToString());
    }

    public string GetScore()
    {
        return score.ToString();
    }

    private void streakUpdate()
    {
        streak++;
        streakText.SetText(streak.ToString());
        if (streak < 5)
        {
            multi = 1;
            multiText.SetText(multi.ToString());
        }
        else if (streak >= 5 && streak < 15)
        {
            multi = 4;
            multiText.SetText(multi.ToString());

        }
        else if (streak >= 15 && streak < 30)
        {
            multi = 8;
            multiText.SetText(multi.ToString());

        }
        else if (streak >= 30)
        {
            multi = 12;
            multiText.SetText(multi.ToString());
        }
    }

    private void backgroundAlphaUpdate(bool success)
    {
        Color current = background.color;
        if (success & current.a < 1)
        {
            current.a += 0.1f;
        } else if (current.a > 0)
        {
            current.a -= 0.1f;
            if (current.a <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        background.color = current;
    }
}
