using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatmaps : MonoBehaviour
{

    List<float> whichNote = new List<float>() {1, 2, 3, 1, 2, 1, 3, 2, 1, 2, 1, 3, 1, 2, 1, 2, 3, 3, 1, 1, 2, 2, 1, 2, 3, 2, 1, 3, 2, 3, 2, 1, 2, 3, 2, 1, 3, 1, 3, 2, 3, 1, 2, 3, 1, 2};

    public int noteMark = 0;

    public Transform BeatsObj;

    public string timerReset = "y";

    public float xPos;
    
    public static int hotStreak = 0;

    public Transform fountain;

    public string fountainSpawn = "n";

    private GameObject leftFount;
    private GameObject rightFount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((timerReset == "y") && (noteMark < 46))
        {
            StartCoroutine (spawnNote());
            timerReset = "n";
        }

        if ((hotStreak==3) && (fountainSpawn == "n"))
        {
            fountainSpawn = "y";

            leftFount = Instantiate(fountain, new Vector3 (-1f, 0f, 0f), Quaternion.Euler(-50, -65, 60)).gameObject;
            rightFount = Instantiate(fountain, new Vector3 (1f, 0f, 0f), Quaternion.Euler(-50, 65, 60)).gameObject;
        }

        if ((hotStreak == 0) && (fountainSpawn == "y"))
        {
            Destroy (leftFount);
            Destroy (rightFount);
            fountainSpawn = "n";
        }

    }

    IEnumerator spawnNote()
    {
        yield return new WaitForSeconds (1); 

        if (whichNote [noteMark] == 1)
        {
            xPos = -1.25f;
        }

        if (whichNote [noteMark] == 2)
        {
            xPos = 0.01f;
        }

        if (whichNote [noteMark] == 3)
        {
            xPos = 1.35f;
        }

        noteMark += 1;
        timerReset = "y";
        Instantiate (BeatsObj, new Vector3 (xPos, 1.028f, 0.03f), BeatsObj.rotation);
    }
}
