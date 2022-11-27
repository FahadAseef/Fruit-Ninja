using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    bool isfruitcut;
    Rigidbody2D _Rigidbody2D;
    public GameObject bladetrial;
    GameObject currentbladetrail;
    CircleCollider2D _circleCollider;
    Vector2 previouspos;
    public float minimumvelocity;
    public Camera cam;
   
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

   
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startcutting();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            stopcutting();
        }
        if (isfruitcut)
        {
            updatecut();
        }

    }

    void updatecut()
    {
       Vector2 currentpos = cam.ScreenToWorldPoint(Input.mousePosition);
        _Rigidbody2D.position = currentpos;
        float velocity = (currentpos-previouspos).magnitude*Time.deltaTime;
        if (velocity > minimumvelocity)
        {
            _circleCollider.enabled = true;
            //Debug.Log(enabled);
        }
        previouspos = currentpos;
    }

    void startcutting()
    {
        isfruitcut = true;
        previouspos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentbladetrail = Instantiate(bladetrial,transform);
        // currentbladetrail.transform.parent = this.transform;
        _circleCollider.enabled = false;

    }

    void stopcutting()
    {
        isfruitcut = false;
       // currentbladetrail.transform.parent=null;
        Destroy(currentbladetrail);
        _circleCollider.enabled = false;
    }

}
