﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MchObject : MonoBehaviour {

    private GameObject denySprite;  //image when collilsion occured
    private uint numOfCollision;    //number of object that collide with this
    private bool isCollided = false;    //check if it is collided with other
    private bool isPicked = false;

    //오브젝트 움직임을 위해
    private Vector3 scrSpace, offset, curScreenSpace;
    protected List<Collider> cols = new List<Collider>();
    protected Rigidbody rb;
    
    public bool isMoved = false;

    #region Getter and setter
    public uint NumOfCollision
    {
        get
        {
            return numOfCollision;
        }
        set
        {
            numOfCollision = value;
        }
    }
    #endregion

    protected virtual void initColliders()
    {
        numOfCollision = 0;

        cols.Add(GetComponent<Collider>());
        foreach (var item in cols)
        {
            item.isTrigger = true;
        }
    }

    protected virtual void setColTrigger(bool isOn)
    {
        if(isOn)
        {
            foreach(var item in cols)
            {
                item.isTrigger = true;
            }
        }
        else
        {
            foreach (var item in cols)
            {
                item.isTrigger = false;
            }
        }
    }

    // Use this for initialization
    public virtual void Start()
    {
        initColliders();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        denySprite = (GameObject)Instantiate(Resources.Load("DenySprite", typeof(GameObject)), Vector3.zero, Quaternion.identity);
        denySprite.SetActive(false);

        scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, scrSpace.z));


        curScreenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, scrSpace.z));
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(Global_Variable.collideObj <= 0)
            {
                if (rb.useGravity == true)
                {
                    rb.useGravity = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    setColTrigger(true);
                    
                }
                else //Simulation Start
                {
                    Global_Variable.isSimulate = true;
                    rb.useGravity = true;
                    setColTrigger(false);
                }
            }
        }

        if(!Global_Variable.isSimulate)
        {
            //  update deny image's position
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -1);
            denySprite.transform.position = pos;

            StartCoroutine("moveObject");
        }
    }

    #region Collision Trigger functions
    /// <summary>
    void OnTriggerEnter(Collider other)
    {
        isCollided = true;
        if (isMoved)
        {
            Global_Variable.collideObj++;
            numOfCollision++;
            if(isPicked)
            {
                denySprite.SetActive(true); //show inhibition image
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        isCollided = false;
        if (isMoved)
        {
            Global_Variable.collideObj--;
            numOfCollision--;
            if (numOfCollision == 0)
            {
                denySprite.SetActive(false);
            }
        }
    }
    /// </summary>
    #endregion Collision Trigger functions

    #region Mouse transform interface
    /// <summary>

    IEnumerator moveObject()
    {
        if (isPicked)
        {
            if ((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) //if mouse cursor move
            {
                Vector3 curScreenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, scrSpace.z));

                if (Global_Variable.curMode == TransformMode.MODE_TRANSLATION)
                {
                    //translation
                    Vector3 curPosition = curScreenSpace + offset;
                    transform.position = curPosition;
                }
                else if (Global_Variable.curMode == TransformMode.MODE_ROTATION)
                {
                    //rotation
                    float theta = (180f / Mathf.PI) * Mathf.Atan2(curScreenSpace.y - transform.position.y,
                        curScreenSpace.x - transform.position.x);
                    transform.rotation = Quaternion.Euler(-theta, 90, 0);
                }
            }

            yield return null;
        }
    }

    void OnMouseDown()
    {
        if (isMoved && !isCollided)
        {
            isPicked = !isPicked;

            scrSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, scrSpace.z));
        }
    }

    /// </summary>
    #endregion Mouse transform interface
}
