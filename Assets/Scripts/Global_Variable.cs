using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ControlMode
{
    CONTROL_MODE_CAMERA,
    CONTROL_MODE_PLAY
}

public enum TransformMode
{
    MODE_TRANSLATION,
    MODE_ROTATION
}

public class Global_Variable : MonoBehaviour {
    
    public static TransformMode curMode = TransformMode.MODE_TRANSLATION;
    public static ControlMode curCtrlMode = ControlMode.CONTROL_MODE_CAMERA;
    public static int collideObj = 0;
    public static bool isSimulate = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            curMode = TransformMode.MODE_TRANSLATION;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            curMode = TransformMode.MODE_ROTATION;
        }
    }
}

[System.Serializable]
public abstract class ButtonIntf : MchObject
{
   abstract public void switchOn();
}