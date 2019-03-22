using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSUI : MonoBehaviour {
    /// <summary>
    /// boss血条默认隐藏 boss房间开启
    /// </summary>
    public bool BossUI = false;
	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (BossUI == true)
        {
            print("asd");
            this.gameObject.SetActive(true);
        }
    }
}
