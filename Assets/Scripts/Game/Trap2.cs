using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour {

    public GameObject trapboom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(trapboom,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
