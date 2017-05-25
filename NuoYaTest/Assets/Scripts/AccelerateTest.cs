using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateTest : MonoBehaviour
{


    public float accelerationRate = 2; // 加速度
    public float currentVelocity = 1; // 当前速度
    public float rotateSpeed = 1; // 旋转速度
    public float rotateAngle = 10; // 旋转角度、偏转角度

    public bool uniform ; // 匀速
    public bool accelerateZ; // Z轴加速
    public bool accelerateY; // Y轴加速

    public enum axisList {
        NONE,
        AXISX,
        Y,
        Z
    }
    public axisList axis = axisList.NONE;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      
        if (uniform)
        {
            transform.Translate(0, 0, currentVelocity);
        }
        if (accelerateZ)
        {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
            transform.Translate(0, 0, currentVelocity);
        }
        if (accelerateY)
        {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
            transform.Translate(0, currentVelocity, 0);
        }

    }
}
