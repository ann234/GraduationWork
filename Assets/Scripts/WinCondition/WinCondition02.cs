using UnityEngine;
using System.Collections;

public class WinCondition02 : MonoBehaviour {

    public float goalForce = 2;
	void OnCollisionEnter(Collision cols)
    {
        float force = cols.relativeVelocity.magnitude;
        if(force > goalForce)
        {
            print("win!");
        }
    }
}
