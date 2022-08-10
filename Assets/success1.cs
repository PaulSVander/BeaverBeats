using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class success1 : MonoBehaviour
{
    public KeyCode activateString;
    public string lockInput = "n";

    public string releasedKey = "n";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if ((Input.GetKeyDown (activateString)) && (lockInput == "n"))
    //    {
    //        Debug.Log ("Input detected");
    //        lockInput = "y";
    //        GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 1.5f);
    //        StartCoroutine (retractCollider ());
    //        releasedKey = "n";
    //    }   

    //    if ((Input.GetKeyUp (activateString)))
    //    {
    //        releasedKey = "y";
    //    }
    //}

    void noteTap()
    {
        Debug.Log("Input detected");
        lockInput = "y";
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1.5f);
        StartCoroutine(retractCollider());
        releasedKey = "n";

        if ((Input.GetKeyUp(activateString)))
        {
            releasedKey = "y";
        }
    }

    IEnumerator retractCollider()
    {
        yield return new WaitForSeconds (0.75f);
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

        if (releasedKey == "n")
        {
            yield return new WaitForSeconds (1);
            StartCoroutine (releaseNote ());
        }

        if (releasedKey == "y")
        {
            StartCoroutine (releaseNote ());
        }
    }

    IEnumerator releaseNote()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -1.5f);
        yield return new WaitForSeconds (0.75f);
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);       
        lockInput = "n";
    }
}
