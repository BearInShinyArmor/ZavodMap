using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMover : MonoBehaviour
{
    public Vector3 StartPosition;
    public float speed;
    public bool offsetOnStart;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
        if (offsetOnStart)
        {
            transform.localPosition=new Vector3(transform.localPosition.x-Screen.width, transform.localPosition.y, transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x-speed*Screen.width*Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
       // StartPosition = transform.localPosition;
        if(transform.localPosition.x< StartPosition.x - Screen.width)
        {
            transform.localPosition = new Vector3(transform.localPosition.x +Screen.width * 2, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
