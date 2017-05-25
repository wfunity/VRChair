using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;
public class GoerVRControll : MonoBehaviour
{

    [StructLayout(LayoutKind.Sequential)]
    public class Packet
    {
        public double px;
        public double py;
        public double pz;
        public double alfx;
        public double alfy;
        public double alfz;
        public double fkRatio = 5;//数据放大系数

    }
    public Packet mypacket = new Packet();
    //Serial
    public string SerialNumberCheck = "";
    [DllImport("Win32Project2.dll")]
    static extern int goervrInitialWashout(double xian_shuiping, double xian_chuixiang);
    [DllImport("Win32Project2")]
    static extern int goervrOpen(string serialNo);
    [DllImport("Win32Project2")]
    static extern int goervrClose();
    [DllImport("Win32Project2.dll")]
    static extern int goervrOnZero();
    [DllImport("Win32Project2.dll")]
    static extern int goervrSettingSampling(int nspan, int nConut);
    [DllImport("Win32Project2")]
    static extern int goervrWrite(Packet packet);

    private Vector3 originPos;
    private float originYaw;
    private float currTime;
    public float updateTime = 0.1f;
    public Transform trackingObject;
    public float roll;
    public float pitch;
    public float yaw;
    public float px;
    public float py;
    public float pz;
    public float fkRatio = 5;
    [Range(0, 2)]
    public double xian_shuiping = 1.0;
    [Range(0, 1)]
    public double xian_chuixiang = 0.85;



    // Use this for initialization
    void Start()
    {

        Thread t = new Thread(new ThreadStart(ThreadData));
        t.Start();
    }
    void OnEnable()
    {

        goervrOpen(SerialNumberCheck);
        //    goervrSettingSampling(10, 5);//采样间隔20ms 5个电机数据运动一次
        //  goervrInitialWashout(xian_shuiping, xian_chuixiang);

    }

    void OnDisable()
    {
        // 初始位置
        goervrOnZero();
        goervrClose();
    }
    // Update is called once per frame
    void LateUpdate()
    {

        if (trackingObject == null)
        {
            Debug.Log("追踪物体没有赋值");
            return;
        }

        currTime -= Time.deltaTime;
        if (currTime <= 0.0f)
        {
            roll = Mathf.DeltaAngle(trackingObject.rotation.eulerAngles.z, 0.0f);
            pitch = Mathf.DeltaAngle(trackingObject.rotation.eulerAngles.x, 0.0f);
            yaw = Mathf.DeltaAngle(trackingObject.rotation.eulerAngles.y, 0.0f);

            originYaw = trackingObject.rotation.eulerAngles.y;
            originPos = trackingObject.position;

            px = trackingObject.position.x;
            py = trackingObject.position.y;
            pz = trackingObject.position.z;

            mypacket.alfx = pitch;
            mypacket.alfy = yaw;
            mypacket.alfz = roll;
            mypacket.px = px;
            mypacket.py = py;
            mypacket.pz = pz;
            mypacket.fkRatio = fkRatio;
            //goervrWrite(mypacket);


            currTime = updateTime;
        }
    }

    void ThreadData()
    {
        Loom.RunAsync(() =>
        {
            goervrWrite(mypacket);
        });

    }
}
