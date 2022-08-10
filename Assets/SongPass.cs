using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SongPass : MonoBehaviour
{
    public TMP_Text scoreDisplay;

    private void Start()
    {
        int score;
        score = PlayerPrefs.GetInt("score", 0);
        scoreDisplay.SetText(score.ToString());
        
    }

    public void SongPassContinue()
    {
        Debug.Log("Pass Continue Press");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }


}
