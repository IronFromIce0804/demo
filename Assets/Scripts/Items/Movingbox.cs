using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingbox : MonoBehaviour {
    /// <summary>
    /// 向右偏移距离
    /// </summary>
    public float xr = 6.0f;
    /// <summary>
    /// 向左偏移距离
    /// </summary>
    public float xl = 3.0f;
    private float dx;
    /// <summary>
    /// x轴方向
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
        dx = transform.position.x;
        if (dx - targetPosition.x >= xr)
        {
            fx = -1;
        }
        if (dx - targetPosition.x <= -xl)
        {
            fx = 1;
        }
        transform.Translate(new Vector3(0.2f * speed * fx, 0, 0));


    }
}
