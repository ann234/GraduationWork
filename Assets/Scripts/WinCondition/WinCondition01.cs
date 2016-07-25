using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class WinCondition01 : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision cols)
    {
        if ( cols.gameObject.tag == "Iron" )
        {
            SceneManager.LoadScene("Scene02");
        }
    }
}
