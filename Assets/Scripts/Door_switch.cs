using UnityEngine;
using System.Collections;

public class Door_switch : ButtonIntf {
    
    public override void switchOn()
    {
        print("door open");

        HingeJoint hj = GetComponent<HingeJoint>();
        JointLimits jl = new JointLimits();
        jl.min = 0;
        jl.max = 90;
        hj.limits = jl;
    }

}
