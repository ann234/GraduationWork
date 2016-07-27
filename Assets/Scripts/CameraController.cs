using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speedX = -20.0f;
    public float speedY = -20.0f;
    public float speedZ = 100.0f;

    public Vector3 minXYZ = new Vector3(-5, 1, -13);
    public Vector3 maxXYZ = new Vector3(5, 10, -3);

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Global_Variable.curCtrlMode == ControlMode.CONTROL_MODE_CAMERA)
        {
            StartCoroutine("moveCamera");
        }
    }

    IEnumerator moveCamera()
    {
        Vector3 camera_pos = Camera.main.transform.position;

        if (Input.GetMouseButton(2))
        {
            float xAxisValue = Input.GetAxis("Mouse X") * speedX * Time.deltaTime;
            float yAxisValue = Input.GetAxis("Mouse Y") * speedY * Time.deltaTime;
            camera_pos += new Vector3(xAxisValue, yAxisValue, 0.0f);
            camera_pos.x = Mathf.Clamp(camera_pos.x, minXYZ.x, maxXYZ.x); //camera_pos.x의 값이 min과 max사이의 값 밖으로 나가지 못하게 한다.
            camera_pos.y = Mathf.Clamp(camera_pos.y, minXYZ.y, maxXYZ.y);

            Camera.main.transform.position = camera_pos;

            yield return null;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float zValue = Input.GetAxis("Mouse ScrollWheel") * speedZ * Time.deltaTime;
            camera_pos += new Vector3(0, 0, zValue);

            //if (Input.GetAxis("Mouse ScrollWheel") > 0)
            //    zValue++;
            //else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            //    zValue--;

            camera_pos.z = Mathf.Clamp(camera_pos.z, minXYZ.z, maxXYZ.z);

            Camera.main.transform.position = camera_pos;

            yield return null;
        }
    }
}
