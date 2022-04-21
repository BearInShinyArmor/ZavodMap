using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoCubeOscillation : MonoBehaviour
{
    public Vector3 StartPosition;
    public float MovingSpeed = 1;
    public float LocalMovingSpeed = 1;
    public float Amplitude = 1;
    public bool MoveLeft = true;
    public bool MoveBack = true;
    public bool MoveOn = false;
    public float MoveBackStall = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
        Amplitude = Screen.width* Amplitude*0.01f;
        MovingSpeed = Screen.width * MovingSpeed * 0.01f;
        LocalMovingSpeed = MovingSpeed;
        transform.localPosition = new Vector3(transform.localPosition.x + Screen.width, transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveOn)
        {
            if (MoveLeft)
            {
                RunForward();
            }
            else
            {
                RunBack();
            }
        }
        if (MoveBack)
        {
            if (MoveBackStall < Time.realtimeSinceStartup)
            {
                MoveToStart();
            }
        }
    }


    public void PointerExitEvent()
    {
        MoveOn = false;
        MoveBack = true;
    }
    public void PointerEnterEvent()
    {
        //Debug.Log(gameObject.name + " rotate");
        MoveOn = true;
    }
    void MoveToStart()
    {
        if (Vector3.Distance(transform.localPosition, StartPosition) > 0.01)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, StartPosition, Screen.width*0.03f);
        }
        else
        {
            MoveBack = false;
        }
    }
    void RunForward()
    {
        //LocalMovingSpeed = LocalMovingSpeed * 2+0.001f*Screen.width;
        transform.localPosition = new Vector3(transform.localPosition.x - LocalMovingSpeed * Screen.width * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
        if ((StartPosition.x - transform.localPosition.x) > Amplitude)
        {
            MoveLeft = false;
            LocalMovingSpeed = MovingSpeed;
        }
    }
    void RunBack()
    {
        //LocalMovingSpeed = LocalMovingSpeed - 1;
        transform.localPosition = new Vector3(transform.localPosition.x + LocalMovingSpeed*Screen.width*Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
        if (( transform.localPosition.x- StartPosition.x ) > Amplitude)
        {
            MoveLeft = true;
            LocalMovingSpeed = MovingSpeed;
        }
    }
}
