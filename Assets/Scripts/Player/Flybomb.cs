using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flybomb : MonoBehaviour {
    Rigidbody2D rig2d;
    private GameObject player;
    /// <summary>
    /// 飞雷神 飞行速度
    /// </summary>
    public float flyspeed = 10f;

    // Use this for initialization
    void Start () {
        rig2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        bool fx = player.GetComponent<SpriteRenderer>().flipX;
        Fly(fx);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void Fly(bool fx)
    {
        
        int f = -1;
        if (fx == true)
        {
            f = -1;
        }
        else f = 1;
        rig2d.velocity = new Vector3(f * flyspeed, 1f, 0);
    }

    void FlyAdd()
    {
        player.GetComponent<Player>().LightningCount=1;//问题：普通爆炸也能刷新飞雷神
    }
}
