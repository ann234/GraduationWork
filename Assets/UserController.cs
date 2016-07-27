using UnityEngine;
using System.Collections;

public interface State
{
    IEnumerator mouseLeftDown();
    IEnumerator mouseRightDown();
    IEnumerator mouseMiddleDown();
    IEnumerator mouseWheelDown();
    IEnumerator mouseWheelMove();
}

class CameraCtrlState : MonoBehaviour ,State
{
    public float speedX = -20.0f;
    public float speedY = -20.0f;
    public float speedZ = 100.0f;

    public Vector3 minXYZ = new Vector3(-5, 1, -13);
    public Vector3 maxXYZ = new Vector3(5, 10, -3);

    private Vector3 camera_pos = Camera.main.transform.position;

    void startCoroutine()
    {
        Vector3 camera_pos = Camera.main.transform.position;


    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("startCoroutine");
    }

    public IEnumerator mouseLeftDown()
    {
        yield return null;
    }

    public IEnumerator mouseRightDown()
    {
        yield return null;
    }

    public IEnumerator mouseMiddleDown()
    {
        yield return null;
    }

    public IEnumerator mouseWheelDown()
    {
        print("mouse left down");
        Vector3 camera_pos = Camera.main.transform.position;
        float xAxisValue = Input.GetAxis("Mouse X") * speedX * Time.deltaTime;
        float yAxisValue = Input.GetAxis("Mouse Y") * speedY * Time.deltaTime;
        camera_pos += new Vector3(xAxisValue, yAxisValue, 0.0f);
        camera_pos.x = Mathf.Clamp(camera_pos.x, minXYZ.x, maxXYZ.x); //camera_pos.x의 값이 min과 max사이의 값 밖으로 나가지 못하게 한다.
        camera_pos.y = Mathf.Clamp(camera_pos.y, minXYZ.y, maxXYZ.y);

        Camera.main.transform.position = camera_pos;

        yield return null;
    }

    public IEnumerator mouseWheelMove()
    {
        Vector3 camera_pos = Camera.main.transform.position;
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

public class UserController : MonoBehaviour {

    private State cameraCtrlState;
    private State objectCtrlState;

    private State state;

    // Use this for initialization
    void Start () {
        cameraCtrlState = new CameraCtrlState();
        state = cameraCtrlState;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(2))    //mouse wheel button down
        {
            state.mouseWheelDown();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)   //mouse wheel move
        {
            print("mouse wheel down");
            state.mouseWheelMove();
        }
    }
}
