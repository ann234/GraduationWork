using UnityEngine;
using System.Collections;

public class Pipe_straight : MchObject {

    protected override void initColliders()
    {
        NumOfCollision = 0;
        
        cols.AddRange(GetComponentsInChildren<Collider>());
        foreach (var item in cols)
        {
            item.isTrigger = true;
        }
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();
	}
}
