using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorto : MonoBehaviour {
    public GameObject target;
    //public GameObject magic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>().Bottom_up())
        {
            //print("asd");
            //Instantiate(magic, transform.position, Quaternion.identity);
            collision.transform.position = target.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
