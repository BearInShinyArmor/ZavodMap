using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartMover : MonoBehaviour
{
    public float MovingStartTime = 0;
    public Vector3 StartPosition;
    float StartAdjustment;
    public float CurrentMovingSpeed = 1;
    public float StartMovingSpeed = 1;
    public float MinimalMovingSpeed = 1;
    public float SpedFadingCoef=0.5f;
    public bool IsNotDone = true;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
        StartAdjustment = Screen.height;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - StartAdjustment, transform.localPosition.z);
        CurrentMovingSpeed = StartMovingSpeed * Screen.height;
        MinimalMovingSpeed = MinimalMovingSpeed * Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNotDone)
        {
            if (Time.realtimeSinceStartup > MovingStartTime)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + CurrentMovingSpeed, transform.localPosition.z);
                if (transform.localPosition.y > StartPosition.y)
                {
                    transform.localPosition = StartPosition;
                    IsNotDone = false;
                }
                CurrentMovingSpeed = CurrentMovingSpeed - CurrentMovingSpeed * Time.deltaTime * SpedFadingCoef;
                if (CurrentMovingSpeed < MinimalMovingSpeed)
                {
                    CurrentMovingSpeed = MinimalMovingSpeed;
                }
            }
        }
    }
}
