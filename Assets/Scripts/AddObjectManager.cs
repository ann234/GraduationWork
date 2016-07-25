using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class AddObjectManager : MonoBehaviour {

    private Transform parentTrans;

    [System.Serializable]
    public class playObject
    {
        public GameObject prefab;
        public int numOfObj;

        public playObject(GameObject _prefab, int _numOfObj)
        {
            prefab = _prefab;
            numOfObj = _numOfObj;
        }
    }
    public List<playObject> objs = new List<playObject>();

	// Use this for initialization
	void Start () {
        parentTrans = GameObject.Find("Objects").transform;

        Quaternion initRot = Quaternion.Euler(0, 90, 0);
        foreach (var item in objs)
        {
            for(int i = 0; i < item.numOfObj; i++)
            {
                GameObject newObj = (GameObject)Instantiate(item.prefab, new Vector3(-7.5f, 7, 0), initRot);
                //newObj.transform.SetParent(parentTrans);
                newObj.GetComponent<MchObject>().isMoved = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
