using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notecontrol : MonoBehaviour
{
    public Transform successBoom;
    public Transform failBoom;
    public ScoreText score;
    public bool tapped = false;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "FailCollider")
        //{
        //    score.noteFail();
        //    Destroy (gameObject);
        //    Debug.Log ("Fail!!!");
        //    Instantiate (failBoom, transform.position, failBoom.rotation);
        //    beatmaps.hotStreak = 0;
        //    Debug.Log ("Hot Streak: " + beatmaps.hotStreak);
        //}

        //if (other.gameObject.name == "success")
        //{
        //    score.noteSuccess();
        //    Destroy (gameObject);
        //    Debug.Log ("Success!!!");
        //    Instantiate (successBoom, transform.position, successBoom.rotation);
        //    beatmaps.hotStreak += 1;
        //    Debug.Log ("Hot Streak: " + beatmaps.hotStreak);
        //}
    }
}
