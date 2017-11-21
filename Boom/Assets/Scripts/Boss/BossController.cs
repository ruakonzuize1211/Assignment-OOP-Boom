using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    GameObject controller;
    public GameObject bomb;
    public float minBombTime = 2;
    public float maxBombTime = 4;
    private float bombTime = 0;
    private float lastBombTime = 0;
    public float throughBombTime = 0.5f;
    private GameObject Bomber;
    private Animator anim;
    public bool activeBoss;

	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController");
        UpdateBombTime();
        Bomber = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBomb", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", false);
    }
	
	// Update is called once per frame
	void Update () {
        activeBoss = controller.GetComponent<GameController>().bossActive;
        if (activeBoss)
        {
            Flip();
            if (Time.time >= lastBombTime + bombTime - throughBombTime)
            {
                anim.SetBool("isBomb", true);
            }
            if (Time.time >= lastBombTime + bombTime)
            {
                ThroughBomb();
            }
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
        bom.GetComponent<BombControler>().boomfromBoss = true;
        bom.GetComponent<BombControler>().target = Bomber.transform.position; //xác định vị trí nhân vật để bom tìm đến nhân vật 
        UpdateBombTime();
        anim.SetBool("isBomb", false);
    }
    //Hàm để tướng xoay theo hướng của Player để bắng bom
    void Flip()
    {
        //Xoay hướng trái
        if(Bomber.transform.position.x<-4.5&&Bomber.transform.position.y<=3&& Bomber.transform.position.y >= -1.5)
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", false);
        }
        //Xoay hướng phải
        else if (Bomber.transform.position.x > 4.5 && Bomber.transform.position.y <= 3 && Bomber.transform.position.y >= -1.5)
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
        }
        //Xoay hướng lên
        else if(Bomber.transform.position.y > 3 && Bomber.transform.position.x < 3.5 && Bomber.transform.position.x > -3.5)
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        //Xoay hướng xuống( hướng mặc định)
        else
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
       
    }
}
