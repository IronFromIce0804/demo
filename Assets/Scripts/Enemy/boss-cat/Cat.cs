using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour {
    /// <summary>
    /// 火球位置
    /// </summary>
    public GameObject[] fireballposition;
    /// <summary>
    /// boss技能 火球
    /// </summary>
    public GameObject fireball;
    /// <summary>
    /// BOSS的召唤物
    /// </summary>
    public GameObject baby;
    public float originspeed = 1;
    /// <summary>
    /// 当前移动速度
    /// </summary>
    public float Speed = 1;
    /// <summary>
    /// 玩家触碰传送门触发BOSS
    /// </summary>
    public GameObject game;
    private SpriteRenderer sp;
    /// <summary>
    /// 眨眼相关基数
    /// </summary>
    private float timecount=1;
    /// <summary>
    /// 眨眼时间
    /// </summary>
    public int eyesTimes = 6;
    /// <summary>
    /// 移动目标点位置
    /// </summary>
    public Vector3 target;
    public GameObject originpos;
    public float catLife=20;
    private Rigidbody2D rig2d;
    public Slider HPStrip;
    //public float runforce = 1.2f;
    /// <summary>
    /// 生命值低于一定程度触发特效火焰
    /// </summary>
    public GameObject catfire;
    /// <summary>
    /// 生命值低于一定程度,受到攻击触发特效反击
    /// </summary>
    public GameObject catlight;
    /// <summary>
    /// 是否开启无敌保护
    /// </summary>
    bool isfire = false;
    bool islight = true;
    Animator anim;
    /// <summary>
    /// 接受伤害并播放动画
    /// </summary>
    bool resethurt=true;
    /// <summary>
    /// 用于判断是否已经开启过火焰保护
    /// </summary>
    public bool fired = false;

    GameObject fire;

    private int fx=1;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        HPStrip.value = HPStrip.maxValue = catLife;
        rig2d = GetComponent<Rigidbody2D>();
        target = transform.position;
        sp = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Eyes();
        DisplayLife();
        CheckBossDead();

        if (game.GetComponent<BossMission>().bossmission == true)
        {
            Run();
        }
        else
        {
            transform.position = originpos.transform.position;
        }
        if (resethurt) { Anim("run"); }
        else Anim("fast");
        if (catLife <= 10)
        {
            if (GameObject.FindGameObjectWithTag("StarM"))
            {
               // print("火焰护盾");
            }
            else
            {
                //print("护盾消失");
                fired = true;
                Destroy(fire);
                isfire = false;
            }
        }

    }

    void Turn(int fx)
    {

    }
    void Eyes()
    {
        if (timecount  >= eyesTimes)
        {
            Anim("eyes");
            timecount = 1;
        }
        timecount+=timecount*Time.deltaTime;
        //print(timecount);
    }

    public void Hurt(float blood,GameObject bombowner)
    {
        if (isfire == false)
        {
            catLife -= blood;
            CheckBossDead();
            if (catLife <= 19 && resethurt == true)
            {
                resethurt = false;
                //print(bombowner.transform.position);
                Speed = 6;
                // transform.Translate(bombowner.transform.position);
                //Anim("fast");

                //Run(bombowner.transform.position);

            }
            //召唤怪物
            int rand = Random.Range(1, 10);
            if (rand > 7) { islight = true; }
            if (islight == true)
            {
                Instantiate(catlight, transform.position - new Vector3(0.7f, 0.35f, 0), Quaternion.Euler(-180, 90, -90));
                Instantiate(baby, transform.position - new Vector3(0.7f, 0.35f, 0), Quaternion.identity);

                islight = false;
            }

            //召唤陨石
            if(catLife<=15 && rand > 7) { FireBall(); }

            if (catLife <= 10 && isfire==false && fired==false)
            {
                HalfHurt();
                //fired = true;
                //print(fired);
            }

        }
    }

    public void HalfHurt()
    {
        
        if (isfire == false)
        {
            fire=Instantiate(catfire, transform.position, Quaternion.Euler(-90, 0, 0));
            isfire = true;
            fired = true;
        }
        Destroy(GameObject.FindGameObjectWithTag("DestoryBosshalf"));
        FireBall();
        
        


    }
    void FireBall()
    {
        int l = fireballposition.Length;
        for (int n = 0; n <= l; n++)
        {
            Instantiate(fireball, fireballposition[n].transform.position, Quaternion.identity);
        }
    }
    /// <summary>
    /// 在动画catsuper结束后调用，使受伤触发动画可用
    /// </summary>
    public void Resthurt()
    {
        resethurt = true;
        Speed = originspeed+0.3f;
        anim.SetBool("catrun", true);
    }

    void DisplayLife()
    {
        // catUI.GetComponent<RectTransform>().localScale.x=catLife*40f;
        HPStrip.value = catLife;
    }

    void Anim(string action)
    {
        switch (action)
        {
            case "eyes":
                anim.SetTrigger("cateyes");
                break;
            case "dead":
                anim.SetTrigger("dead");
                break;
            case "run":
                //Run();
                anim.SetBool("catrun",true);
                break;
            case "fast":
                //print("ss");
                anim.SetBool("catrun",false);
                anim.SetTrigger("catfast");
                break;
            default:
                break;
        }
    }

    void Run()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p.transform.position.x > transform.position.x) { fx = 1;sp.flipX = true; }
        else
        {
            fx = -1;
            sp.flipX = false;
        }
        transform.Translate(new Vector3(Speed * fx, 0, 0) * Time.deltaTime);
        //Anim("run");
        
    }
    void Run(Vector3 pos)
    {
        //transform.position = Vector2.Lerp(new Vector3(pos.x,0,0), target, Time.deltaTime);
        //Anim("fast");
    }

    void CheckBossDead()
    {
        if (catLife <= 0)
        {
            Destroy(this.gameObject);
            print("YOU WIN");
        }
    }
    
}
