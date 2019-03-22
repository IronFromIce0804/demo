using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catfire : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindGameObjectWithTag("BOSS");
        //print(target);
        transform.position = target.transform.position-new Vector3(0,1,0);
	}
}
