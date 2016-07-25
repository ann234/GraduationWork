using UnityEngine;
using System.Collections;

public class CatapultBtn : MonoBehaviour {

    public GameObject gObj_arm;
    public bool istri;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
	    
	}

    void OnCollisionEnter(Collision cols)
    {
        if(cols.relativeVelocity.magnitude > 2)
        {
            //cols.rigidbody.AddForce(new Vector3(1, 1, 0).normalized * 200);
            
            HingeJoint hinge_arm = gObj_arm.GetComponent<HingeJoint>();

            hinge_arm.useSpring = true;
            JointSpring spring = hinge_arm.spring;
            spring.spring = 300;
            spring.damper = 3;
            spring.targetPosition = 100;

            hinge_arm.spring = spring;

            //JointMotor motor = hinge_arm.motor;
            //motor.force = 100;
            //motor.targetVelocity = 500;
            //motor.freeSpin = false;

            //hinge_arm.motor = motor;
        }
    }
}
