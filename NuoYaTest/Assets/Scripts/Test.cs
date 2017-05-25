using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Test : MonoBehaviour {
    public float speed=1;
	// Use this for initialization
	void Start () {
        Thread t = new Thread(new ThreadStart(ThreadData));
        t.Start();
	}
	
	// Update is called once per frame
	void Update () {
     //   speed += 0.1f;
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime*speed);
   
	}

    void ThreadData() {
       // speed -= 0.1f;
        Debug.Log(speed);
    }
}
