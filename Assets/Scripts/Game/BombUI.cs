using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombUI : MonoBehaviour {
    private GameObject player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Text text = this.GetComponent<Text>();
            int bombNumb = player.GetComponent<Player>().bombNumb;
            text.text = bombNumb.ToString();
        }
    }
}
