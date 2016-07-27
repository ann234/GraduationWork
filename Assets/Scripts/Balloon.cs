using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    private Rigidbody rb;

    public float force2Up = 4;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(rb.velocity.magnitude < force2Up)
        {
            rb.AddForce(new Vector3(0, 2, 0));
        }
	}
}
