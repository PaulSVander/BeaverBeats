using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongFail : MonoBehaviour
{
    public void SongFailContinue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
}
