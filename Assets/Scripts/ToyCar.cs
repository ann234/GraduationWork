using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToyCar : MchObject {

    public float motorForce = 0;
    public float maxMotorForce = 5;
    public Collider Body;
    public WheelCollider WheelColFR;
    public WheelCollider WheelColFL;
    public WheelCollider WheelColBR;
    public WheelCollider WheelColBL;

    public GameObject[] Wheels;

    private bool motorOn = false;

    protected override void initColliders()
    {
        //GetComponent<Rigidbody>().centerOfMass.Set(0, 0.5f, 0);
        foreach(var item in GetComponentsInChildren<Collider>())
        {
            cols.Add(item);
        }
    }

    protected override void setColTrigger(bool isOn)
    {
        base.setColTrigger(isOn);
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();
        if(motorOn)
        {
            foreach (GameObject wheel in Wheels)
            {
                WheelCollider col = wheel.GetComponent<WheelCollider>();
                col.motorTorque = motorForce;

                Quaternion q;
                Vector3 p;
                col.GetWorldPose(out p, out q);
                col.transform.GetChild(0).position = p;
                col.transform.GetChild(0).rotation = q;
            }
        }
    }

    public void OnCollisionEnter(Collision cols)
    {
        if(cols.relativeVelocity.magnitude > 2)
        {
            motorOn = true;
        }
    }
}
