using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

    private Rigidbody rb;

    private GameObject[] ironObjs;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if(ironObjs == null)
        {
            ironObjs = GameObject.FindGameObjectsWithTag("Iron");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Global_Variable.isSimulate)
        {
            foreach (GameObject obj in ironObjs)
            {
                Rigidbody obj_rb = obj.GetComponent<Rigidbody>();
                Vector3 offset = rb.position - obj_rb.position;
                Vector3 dir = offset.normalized;
                float len = offset.magnitude;
                if (len < 5)
                {
                    obj_rb.AddForce(20 * (1 / len) * dir);
                }
            }
        }
    }
}
