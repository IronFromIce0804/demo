using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upmagic : MonoBehaviour {
    public float force = 800f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        //print("s");
    }
}
