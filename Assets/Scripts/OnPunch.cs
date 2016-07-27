using UnityEngine;
using System.Collections;

public class OnPunch : MchObject {

    private Collider col;
    private SpringJoint sp;

    // Use this for initialization
    public override void Start()
    {
        col = GetComponent<Collider>();
        rb = col.attachedRigidbody;
        sp = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    public override void Update () {
	
	}

    void OnCollisionEnter(Collision cols)
    {
        if(cols.transform.tag != "Glove")
        {
            if (cols.relativeVelocity.magnitude > 2)
            {
                Rigidbody connectedRb = sp.connectedBody;
                connectedRb.isKinematic = false;
                Vector3 dir = (connectedRb.position - rb.position).normalized;
                connectedRb.AddForce(dir * 500);
            }
        } 
        
    }
}
