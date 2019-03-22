using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏角色相关
/// </summary>
public class Player : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sp;
    Rigidbody2D rig2d;
    public float speed = 5f;
    private float deltaX;//键盘水平移动
    private float deltay;
    public float jumpForce = 300f;
    /// <summary>
    /// 关卡
    /// </summary>
    public int mission = 0;
    public bool door1open = false;//是否通关关卡1
    /// <summary>
    /// 跳跃时所判断的地板层
    /// </summary>
    public LayerMask mask;
    private bool isGround;//是否在地板上
    /// <summary>
    /// 生命数
    /// </summary>
    public int liveCount = 10;
    /// <summary>
    /// 是否已死亡
    /// </summary>
    public bool isDead = false;
    /// <summary>
    /// 角色是否为可控
    /// </summary>
    private bool isControl = true;
    /// <summary>
    /// 是否按下上键
    /// </summary>
    public bool bottom_up_down = false;
    public float deathHigh = -2f;
    //public Camera mycamera;

    public Transform[] beginpoint;//检查点数组

    public GameObject bomb;
    public GameObject flybomb;
    public int bombNumb = 10;
    /// <summary>
    /// 飞雷神可用 1可用 0不可用
    /// </summary>
    int Lightfly=1;
    /// <summary>
    /// 飞雷神可用次数
    /// </summary>
    public int LightningCount=0;
    /// <summary>
    /// 飞雷神炸弹预制体
    /// </summary>
    GameObject Lbomb;
    /// <summary>
    /// 飞雷神瞬移特效
    /// </summary>
    public GameObject magic;
    /// <summary>
    /// 主菜单
    /// </summary>
    public GameObject mainmenu;
    /// <summary>
    /// UI显示游戏结束
    /// </summary>
    public GameObject die;
    // Use this for initialization
    void Start()
    {
        
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rig2d = GetComponent<Rigidbody2D>();
        //mycamera = Camera.
    }

    // Update is called once per frame
    void Update()
    {

        Control();
        CheckDeath();
        
      
    }
    void FixedUpdate()
    {
        isGround = Checkground();
    }

    void Control()
    {
        if (isControl)
        {
            Run();
            Jump();
            SetBomb();
            Lightning();
            Bottom_up();
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {

            rig2d.AddForce(Vector2.up * jumpForce);
            Anim("jump");
        }
        else if (isGround)
        {
            Anim("jumpover");
        }

        // Physics2D.Raycast();
    }

    void Run()
    {
        deltaX = Input.GetAxis("Horizontal");
        float y = rig2d.velocity.y;

        Vector2 run = new Vector2(deltaX * speed, y);
        //transform.Translate(run);
        rig2d.velocity = run;
        Anim("move");
    }

    void SetBomb()
    {
        float fxlittle;
        if (Input.GetKeyDown(KeyCode.L) && bombNumb>=1)
        {
            if (sp.flipX) { fxlittle = -0.5f; }
            else { fxlittle = 0.5f; }
            Instantiate(bomb,transform.position+new Vector3(fxlittle,0,0),Quaternion.identity);
            Anim("setbomb");
            bombNumb--;
            //print(bombNumb);
        }
    }
    /// <summary>
    /// 飞雷神
    /// </summary>
    void Lightning()
    {
         
        int f = 1;
        if (sp.flipX == true) { f = -1; }
        else { f = 1; }

        Lbomb = GameObject.FindGameObjectWithTag("flybomb");
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            if (Lbomb&&Lightfly==1)
            {
                transform.position = Lbomb.transform.position;
                Instantiate(magic, transform.position, Quaternion.Euler(90,0,0));
                Lbomb.transform.position=new Vector3(-500,-500,20);//传送后将炸弹移出视线视线隐藏，因需要动画结束来调用函数 因此不能删除Lbomb
                Lightfly = 0;
            }
            else {

                if (LightningCount > 0)
                {
                    Instantiate(flybomb, transform.position + new Vector3(f * 0.5f, 0.5f, 0), Quaternion.identity);
                    
                    LightningCount = 0;
                    Lightfly = 1;
                   // LightningCount--;
                }
                   // else print("没有找到雷");
                
            }
        }
        
        float timecount=0;
        if (timecount >= Time.deltaTime * 5)
        {
            timecount += Time.deltaTime;
            LightningCount = 1;
        }
        
    }

    void Anim(string action)
    {
        switch (action)
        {
            case "move":
                anim.SetFloat("moveorstand", Mathf.Abs(deltaX));
                if (deltaX < 0)
                {
                    sp.flipX = true;
                }
                else if (deltaX > 0)
                {
                    sp.flipX = false;
                }
                break;
            case "jump":
                anim.SetInteger("jumpint", 10);
                break;
            case "jumpover":
                anim.SetInteger("jumpint", 1);
                break;
            case "setbomb":
                anim.SetTrigger("setbomb");
                break;
            case "dead":
                anim.SetTrigger("dead");
                break;
            default:
                break;
        }
    }
    public bool Checkground()
    {
        RaycastHit2D hit2d = Physics2D.BoxCast(transform.position + new Vector3(0, -0.5f, 0), new Vector3(0.5f, 0.1f, 0), 0, Vector2.down, 0.1f, mask);
        if (hit2d.collider)
        {

            return true;
        }
        else
        {

            return false;
        }
    }

    void CheckDeath()
    {
        if (mission == 0)
        {
            if (transform.position.y <= deathHigh)
            {
                isDead = true;
                Death();
                
            }
        }
        else if (mission == 1)
        {
            if (transform.position.y <= -27f)
            {
                isDead = true;
                Death();
            }
        }

    }

  
    /// <summary>
    /// 触发角色死亡，dead动画后将调用TryRelive
    /// </summary>
    public void Death()
    {
        isControl = false;
        isDead = true;
        Anim("dead");
        //isDead = false;

        
    }
    /// <summary>
    /// 动画dead之后自动调用
    /// </summary>
    public void TryRelive()
    {
        
       
        
            if (liveCount >= 1)
            {
                transform.position = beginpoint[mission].position;
                isControl = true;
                liveCount--;
                isDead = false;
                GameObject.FindGameObjectWithTag("CheckBossDoor").GetComponent<BossMission>().bossmission = false;
        }
            else
            {
                mainmenu.SetActive(true);
                die.SetActive(true);
                this.gameObject.SetActive(false) ;
                //print("game over");
                
                
             }
        
    }
    /// <summary>
    /// 按下上键
    /// </summary>
    /// <returns></returns>
    public bool Bottom_up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        else return false;
    }
}
