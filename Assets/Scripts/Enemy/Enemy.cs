using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Player;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (other.transform.tag=="Player" && p.isDead==false) {
            
            p.Death();
        }
    }
}
