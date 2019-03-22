using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMission : MonoBehaviour {
    /// <summary>
    /// 是否已进入boss关
    /// </summary>
    public bool bossmission=false;
    public GameObject BossUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossmission = true;
           
            BossUI.SetActive(true);

            collision.gameObject.GetComponent<Player>().mission = 2;
            
        }
    }
}
