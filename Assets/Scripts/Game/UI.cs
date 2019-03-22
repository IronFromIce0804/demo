using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private GameObject player;

    // Use this for initialization
    void Start () {

       
       // text.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Text text = this.GetComponent<Text>();
            int liveCount = player.GetComponent<Player>().liveCount;
            text.text = liveCount.ToString();
        }
    }
}
