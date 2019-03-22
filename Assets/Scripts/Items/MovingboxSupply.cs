using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingboxSupply : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = this.gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
