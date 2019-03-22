using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingother : MonoBehaviour {
    /// <summary>
    /// 插值移动目标
    /// </summary>
    //public GameObject targetopint;
   // private Vector3 target;
   // private Vector3 originposition;
    private int n=0;
    public GameObject[] targetopint;
    // Use this for initialization
    void Start () {
        
        //target = targetopint[n+1].transform.position;
        
        //originposition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {


        transform.position = Vector3.Lerp(transform.position, targetopint[n].transform.position, Time.deltaTime);
        if (Mathf.Abs( transform.position.x - targetopint[n].transform.position.x) <= 0.1f)
        {
            transform.position = targetopint[n].transform.position;
            n++;
            if (n >= targetopint.Length) { n = 0; }
        }
        


        //if (Mathf.Abs(transform.position.x - target.x) >= 0.1f && fx==1)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        //}
        //else if (Mathf.Abs(transform.position.x - target.x) <= 0.1f)
        //{
        //    transform.position = target;
        //    fx = -1;
        //}
        // if(fx==-1)
        //{
        //    //transform.position = target;
        //    //target = originposition;
        //    transform.position = Vector3.Lerp(transform.position, originposition, Time.deltaTime);
        //    fx = -1;
        //}
    }
}
