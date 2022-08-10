using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBoard : MonoBehaviour
{
    public KeyCode activateString;
    public string lockInput = "n";
    public Transform successBoom;
    public Transform failBoom;

    public string releasedKey = "n";
    public bool beatColliding = false;
    public ScoreText score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Beat")
        {
            Debug.Log("Beat Collision");
            beatColliding = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("on stay");
        Debug.Log(Input.touchCount);
        if (Input.touchCount > 0 & other.tag == "Beat")
        {
            score.noteSuccess();
            Debug.Log("Success!!!");
            Instantiate(successBoom, transform.position, successBoom.rotation);
            beatmaps.hotStreak += 1;
            Destroy(other.gameObject);
            Debug.Log("touched  touched touched");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit " + other.name);
        if (other.tag == "Beat")
        {
            score.noteFail();
            Debug.Log("Stopped Collision");
            beatColliding = false;
            Destroy(other.gameObject);
            //Instantiate(failBoom, transform.position, failBoom.rotation);
            beatmaps.hotStreak = 0;
            Debug.Log("Hot Streak: " + beatmaps.hotStreak);
        }
        
    }
}
