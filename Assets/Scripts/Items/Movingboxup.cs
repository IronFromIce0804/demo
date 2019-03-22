using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingboxup : MonoBehaviour {

    /// <summary>
    /// 向上偏移距离
    /// </summary>
    public float yu = 6.0f;
    /// <summary>
    /// 向下偏移距离
    /// </summary>
    public float yd = 3.0f;
    private float dy;
    /// <summary>
    /// y轴方向
    /// </summary>
    public int fx = -1;
    public float speed = 0.15f;
    Vector2 targetPosition;
    // Use this for initialization
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dy = transform.position.y;
        if (dy - targetPosition.y >= yu)
        {
            fx = -1;
        }
        if (dy - targetPosition.y <= -yd)
        {
            fx = 1;
        }
        transform.Translate(new Vector3(0,0.2f * speed * fx,  0));


    }
}
