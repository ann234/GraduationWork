using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour {
    
    private List<MchObject> mchObjects = new List<MchObject>();

    // Use this for initialization
    void Start () {
        mchObjects.AddRange( GameObject.FindObjectsOfType<MchObject>() );   //모든 MchObject 타입의 오브젝트를 가져온다.
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Click()
    {
        if (Global_Variable.collideObj <= 0)
        {
            foreach(MchObject obj in mchObjects)
            {
                obj.Simulation(!Global_Variable.isSimulate);    //모든 MchObject의 상태를 시뮬레이션 상태로 전환
            }
            Global_Variable.isSimulate = !Global_Variable.isSimulate;   //전역변수 isSimulate를 변경한다.
        }
    }
}
