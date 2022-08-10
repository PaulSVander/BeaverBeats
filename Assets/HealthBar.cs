using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    private const int HealthLost = 2;
    private const int HealthGained = 5;

    void Start()
    {
        slider.maxValue = 100;
        slider.value = 100;
    }

    public void LoseHealth()
    {
        // decrement health by "HealthLost"
        // trigger fail scenario (WIP) if health is 0
        Debug.Log("Lost Health");
        slider.value -= HealthLost;
        if (slider.value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GainHealth()
    {
        // increment health by "HealthGained" but no more than 100
        if (slider.value >= slider.maxValue - HealthGained)
        {
            slider.value = 100;
        }
        else
        {
            slider.value += HealthGained;
        }
    }
}

