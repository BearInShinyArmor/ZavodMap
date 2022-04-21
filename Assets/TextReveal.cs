using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReveal : MonoBehaviour
{
    public bool isOn = false;
    public float RotationSpeed = 60;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation.ToString());
        //Debug.Log(transform.eulerAngles.ToString());
        if (isOn && transform.eulerAngles.y > 0)
        {//уменьшаем до нуля            
            transform.Rotate(new Vector3(0, -RotationSpeed * Time.deltaTime, 0));
            if (transform.eulerAngles.y > 350)
            {
                //transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w));
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (!isOn && transform.eulerAngles.y < 90)
        {//увеличиваем до 90
            transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0));
            if (transform.eulerAngles.y > 90)
            {
                //transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 90, transform.rotation.z, transform.rotation.w));
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
    }
    public void SetOnOf()
    {
        isOn = !isOn;
    }
    public void SetOnOf(bool b)
    {
        isOn = b;
    }
}
