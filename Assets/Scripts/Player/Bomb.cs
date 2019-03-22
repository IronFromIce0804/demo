using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    public LayerMask enemy;
    public LayerMask boss;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //int bombNumb = player.GetComponent<Player>().bombNumb;
        //AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        //// 判断动画是否播放完成
        //if (info.normalizedTime >= 0.97f)
        //{
        //    Destroy(GetComponent<BoxCollider2D>());
        //    Destroy(GetComponent<Rigidbody2D>());

        //    CheckBoomEnemy();//判断是否是敌人属性是则删除敌人

        //    CheckBoomBOSS();
           
        //    if (info.normalizedTime >= 1.0f)//结束后删除炸弹
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
    }
    public void Bombaction(string action)
    {
        //int bombNumb = player.GetComponent<Player>().bombNumb;
        switch (action)
        {
            case "booming":
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<Rigidbody2D>());
                CheckBoomEnemy();//判断是否是敌人属性是则删除敌人

                CheckBoomBOSS();
                break;
            case "boomover":
                Destroy(this.gameObject);
                break;


        }

    }
    public void CheckBoomEnemy()
    {
        RaycastHit2D boom2D = Physics2D.BoxCast(transform.position + new Vector3(0, 0.5f, 0), new Vector3(2f, 0.5f, 0), 0, Vector2.up, 2f, enemy);
        if (boom2D.collider)
        {
            Destroy(boom2D.collider.gameObject);
            
        }
        else
        {
           
        }

    }
    public void CheckBoomBOSS()
    {
        RaycastHit2D boom2D = Physics2D.BoxCast(transform.position + new Vector3(0, 0.5f, 0), new Vector3(2f, 0.5f, 0), 0, Vector2.up, 2f, boss);
        player = GameObject.FindGameObjectWithTag("Player");
        if (boom2D.collider)
        {
           Cat Thiscat= boom2D.collider.gameObject.GetComponent<Cat>();
            
            Thiscat.Hurt(1, player);
            
        }
        else
        {
            
        }
    }
}
