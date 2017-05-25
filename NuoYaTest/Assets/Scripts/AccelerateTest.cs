using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateTest : MonoBehaviour
{


    public float accelerationRate = 2; //加速度
    public float currentVelocity = 1;

    public bool accelerateZ; //Z轴加速
    public bool accelerateY; //Y轴加速
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
