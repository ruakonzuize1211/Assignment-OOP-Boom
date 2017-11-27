using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    public bool bossActive = false;
    public float speed = 1.5f;
    public GameObject bomb, controller;
    public float minBombTime = 2;
    public float maxBombTime = 4;
    private float bombTime = 0;
    private float lastBombTime = 0;
    public float throughBombTime = 0.5f;
    private GameObject Bomber;
    private GameObject Boss;
    private Animator anim;
    public bool stopUp, stopDown, stopLeft, stopRight;
    direction lastDirection;
    Transform rayUp, rayDown, rayLeft, rayRight;
    RaycastHit2D hitUp, hitDown, hitLeft, hitRight;
    private float x1, x2, y1, y2, subx, suby;

    public enum direction { up, right, down, left, multidir };
    // Use this for initialization
    void Start () {
        lastDirection = direction.down;
        rayUp = transform.Find("rayUp");
        rayRight = transform.Find("rayRight");
        rayDown = transform.Find("rayDown");
        rayLeft = transform.Find("rayLeft");
        UpdateBombTime();
        Boss = GameObject.FindGameObjectWithTag("boss");
        Bomber = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.FindGameObjectWithTag("GameController");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isExplode", false);
        anim.SetBool("isDie", false);
        anim.SetBool("isBomb", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", false);
    }
    public void FixedUpdate()
    {
        hitUp = Physics2D.Raycast(rayUp.position, new Vector2(0, 1f), 0.1f);
        if (hitUp.collider != null)
        {
                stopUp = true;
        }
        else
            stopUp = false;
        //MoveDown
        hitDown = Physics2D.Raycast(rayDown.position, new Vector2(0, -1f), 0.1f);
        if (hitDown.collider != null)
        {
            stopDown = true;
        }
        else
            stopDown = false;
        //Move Right
        hitRight = Physics2D.Raycast(rayRight.position, new Vector2(1f, 0), 0.5f);
        if (hitRight.collider != null)
        {
            stopRight = true;
        }
        else
            stopRight = false;
        //Move left
        hitLeft = Physics2D.Raycast(rayLeft.position, new Vector2(-1f, 0), 0.5f);
        if (hitLeft.collider != null)
        {
            stopLeft = true;
        }
        else
            stopLeft = false;
    }
    // Update is called once per frame
    void Update () {
        Bomber = GameObject.FindGameObjectWithTag("Player");
        bossActive = controller.GetComponent<GameController>().bossActive;
        if(bossActive)
        {
            Flip1();
            autoMove();
        }
        else
        {
            Flip();
        }
        if (Time.time >= lastBombTime + bombTime-throughBombTime)
        {
            anim.SetBool("isBomb", true);
        }
        if (Time.time >= lastBombTime + bombTime)
        {
            ThroughBomb();
        }
    }

    void UpdateBombTime()
    {
        lastBombTime = Time.time;
        bombTime = Random.Range(minBombTime, maxBombTime + 1);
    }

    void ThroughBomb()
    {
        GameObject bom = Instantiate(bomb,transform.position,Quaternion.identity) as GameObject;
        bom.GetComponent<BombControler>().throwbyBoss = true;
        subx = Bomber.transform.position.x - (float)Mathf.RoundToInt(Bomber.transform.position.x);//>0 khi toa do lam tron nho hon
        suby = Bomber.transform.position.y - (float)Mathf.RoundToInt(Bomber.transform.position.y);
        x1 = Mathf.RoundToInt(Bomber.transform.position.x) + 0.5f;
        x2 = Mathf.RoundToInt(Bomber.transform.position.x) - 0.5f;
        y1 = Mathf.RoundToInt(Bomber.transform.position.y) + 0.5f;
        y2 = Mathf.RoundToInt(Bomber.transform.position.y) - 0.5f;
        if (subx > 0.0f && suby > 0.0f)
        {
            bom.GetComponent<BombControler>().target = new Vector2( x1,y1); //xác định vị trí nhân vật để bom tìm đến nhân vật 
            UpdateBombTime();
            anim.SetBool("isBomb", false);
        }
        if (subx > 0.0f && suby < 0.0f)
        {
            bom.GetComponent<BombControler>().target = new Vector2(x1, y2); //xác định vị trí nhân vật để bom tìm đến nhân vật 
            UpdateBombTime();
            anim.SetBool("isBomb", false);
        }
        if (subx < 0.0f && suby > 0.0f)
        {
            bom.GetComponent<BombControler>().target = new Vector2(x2, y1); //xác định vị trí nhân vật để bom tìm đến nhân vật 
            UpdateBombTime();
            anim.SetBool("isBomb", false);
        }
        if (subx < 0.0f && suby < 0.0f)
        {
            bom.GetComponent<BombControler>().target = new Vector2(x2, y2); //xác định vị trí nhân vật để bom tìm đến nhân vật 
            UpdateBombTime();
            anim.SetBool("isBomb", false);
        }
       
    }

    //Hàm để tướng xoay theo hướng của Player để bắng bom
    void Flip()
    {
        //Xoay hướng trái
        if(Bomber.transform.position.x<-2.5&&Bomber.transform.position.y<=3&& Bomber.transform.position.y >= -1)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
        }
        //Xoay hướng phải
        else if (Bomber.transform.position.x > 2.5 && Bomber.transform.position.y <= 3 && Bomber.transform.position.y >= -1)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
         
        }
        //Xoay hướng lên
        else if(Bomber.transform.position.y > 3)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", true);
        
        }
        //Xoay hướng xuống( hướng mặt định)
        else
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", true);
        }
    }

    void Flip1()
    {
        //Xoay hướng trái
        if (Bomber.transform.position.x < Boss.transform.position.x && Bomber.transform.position.y < 1 && Bomber.transform.position.y > -1)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
        }
        //Xoay hướng phải
        else if (Bomber.transform.position.x > Boss.transform.position.x && Bomber.transform.position.y < 1 && Bomber.transform.position.y > -1)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);

        }
        //Xoay hướng lên
        else if (Bomber.transform.position.y > Boss.transform.position.y)
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", true);

        }
        //Xoay hướng xuống( hướng mặt định)
        else
        {
            anim.SetBool("isExplode", false);
            anim.SetBool("isDie", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", true);
        }
    }

    void moveRight()
    {
        transform.position -= Vector3.left * speed * Time.deltaTime;
    }
    void moveLeft()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }
    void moveUp()
    {
        transform.position -= Vector3.down * speed * Time.deltaTime;
    }
    void moveDown()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }
    public void bosshitBoom()
    {
        anim.SetBool("isDie", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isDown", false);
        anim.SetBool("isExplode", true);
        gameObject.GetComponent<BossHealth>().AddDamge(5f);
    }
    void autoMove()
    {
        if (lastDirection == direction.up && !stopUp)
        {
            moveUp();
            return;
        }
        else if (lastDirection == direction.right && !stopRight)
        {
            moveRight();
            return;
        }
        else if (lastDirection == direction.down  && !stopDown)
        {
            moveDown();
            return;
        }
        else if (lastDirection == direction.left  && !stopLeft)
        {
            moveLeft();
            return;
        }
        List<direction> temp = new List<direction>();
        if (!stopUp)
            temp.Add(direction.up);
        if (!stopRight)
            temp.Add(direction.right);
        if (!stopDown)
            temp.Add(direction.down);
        if (!stopLeft)
            temp.Add(direction.left);
        if (temp.Count > 0)
        {
            int rnd = Random.Range(0, temp.Count);
            if (temp[rnd] == direction.up)
            {
                moveUp();
                lastDirection = direction.up;
            }
            else if (temp[rnd] == direction.right)
            {
                moveRight();
                lastDirection = direction.right;
            }
            else if (temp[rnd] == direction.left)
            {
                moveLeft();
                lastDirection = direction.left;
            }
            else if (temp[rnd] == direction.down)
            {
                moveDown();
                lastDirection = direction.down;
            }
        }
    }
}
