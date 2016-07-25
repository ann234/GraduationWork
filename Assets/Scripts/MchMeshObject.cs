using UnityEngine;
using System.Collections;

public class MchMeshObject : MchObject {

    protected override void initColliders()
    {
        NumOfCollision = 0;

        cols.Add(GetComponent<Collider>());
        ((MeshCollider)cols[0]).convex = true;
        cols[0].isTrigger = true;
    }

    protected override void setColTrigger(bool isOn)
    {
        if (isOn)
        {
            ((MeshCollider)cols[0]).convex = true;
            cols[0].isTrigger = true;
        }
        else
        {
            cols[0].isTrigger = false;
            ((MeshCollider)cols[0]).convex = false;
        }
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
