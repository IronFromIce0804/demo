using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBomb : MonoBehaviour {
    public GameObject magic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(magic,transform.position,Quaternion.identity);
            collision.GetComponent<Player>().bombNumb++;

        }
    }
}
