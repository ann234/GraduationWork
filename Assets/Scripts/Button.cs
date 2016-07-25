using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public float needForce = 2.0f;
    
    public ButtonIntf btn;

    private GameObject door;

	// Use this for initialization
	void Start () {
        door = GameObject.Find("Door");
	}

    // Update is called once per frame
    void Update() {

	}

    void OnCollisionEnter(Collision cols)
    {
        if(cols.relativeVelocity.magnitude > needForce)
        {
            btn.switchOn();
        }
    }
}
