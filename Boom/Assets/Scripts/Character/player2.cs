﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player2 : MonoBehaviour {
    bool isActive = true;
    float timetoMove;
    bool canMove;
    public Text LifeTxt;
    public Text BSizeTxt;
    public Text ShoeTxt;
    public Text BombTxt;
    public int nummberofHeart = 3;
    public int BSize = 0;
    public int Shoe = 0;
    public int Bomb = 0;
    public bool isMultiboom = false;
    bool stopScreen = false;
    public float speed;
    public int rangeofBoom = 1;
    private Animator anim;
    public bool stopUp1, stopDown1, stopRight1, stopLeft1, stopUp2, stopDown2, stopRight2, stopLeft2;
    public bool ishitZombieup, ishitZombiedown, ishitZombieleft, ishitZombieright;
    Transform rayUp1, rayRight1, rayDown1, rayLeft1, rayUp2, rayLeft2, rayDown2, rayRight2, rayUp, rayDown, rayLeft, rayRight;
    RaycastHit2D hitUp, hitUp1, hitUp2, hitDown, hitDown1, hitDown2, hitLeft, hitLeft1, hitLeft2, hitRight, hitRight1, hitRight2;
    public GameObject soundItem;
    

    bool G;
    [SerializeField]
    void Start () {
        timetoMove = 4f;
        canMove = true;
        G = false;
        LifeTxt.text = "x " + nummberofHeart;
        BombTxt.text = "x " + Bomb;
        ShoeTxt.text = "x " + Shoe;
        BSizeTxt.text = "x " + BSize;
        speed = 2f;
        rayUp1 = transform.Find("rayUp1");
        rayRight1 = transform.Find("rayRight1");
        rayDown1 = transform.Find("rayDown1");
        rayLeft1 = transform.Find("rayLeft1");
        rayUp2 = transform.Find("rayUp2");
        rayRight2 = transform.Find("rayRight2");
        rayDown2 = transform.Find("rayDown2");
        rayLeft2 = transform.Find("rayLeft2");
        rayUp = transform.Find("rayUp");
        rayRight = transform.Find("rayRight");
        rayDown = transform.Find("rayDown");
        rayLeft = transform.Find("rayLeft");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isRevival", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
    }
    private void FixedUpdate()
    {
        //Raycast for every directions
        hitUp = Physics2D.Raycast(rayUp.position, new Vector2(0, 1f), 0.1f);
        hitDown = Physics2D.Raycast(rayDown.position, new Vector2(0, -1f), 0.1f);
        hitRight = Physics2D.Raycast(rayRight.position, new Vector2(1f, 0), 0.1f);
        hitLeft = Physics2D.Raycast(rayLeft.position, new Vector2(-1f, 0), 0.1f);
        hitUp1 = Physics2D.Raycast(rayUp1.position, new Vector2(0, 1f), 0.1f);
        hitUp2 = Physics2D.Raycast(rayUp2.position, new Vector2(0, 1f), 0.1f);
        hitDown1 = Physics2D.Raycast(rayDown1.position, new Vector2(0, -1f), 0.1f);
        hitDown2 = Physics2D.Raycast(rayDown2.position, new Vector2(0, -1f), 0.1f);
        hitRight1 = Physics2D.Raycast(rayRight1.position, new Vector2(1f, 0), 0.5f);
        hitRight2 = Physics2D.Raycast(rayRight2.position, new Vector2(1f, 0), 0.5f);
        hitLeft1 = Physics2D.Raycast(rayLeft1.position, new Vector2(-1f, 0), 0.5f);
        hitLeft2 = Physics2D.Raycast(rayLeft2.position, new Vector2(-1f, 0), 0.5f);
        //Array of all raycasts
        RaycastHit2D[] groupRaycast = { hitUp, hitUp1, hitUp2, hitLeft, hitLeft1, hitLeft2, hitRight, hitRight1, hitRight2, hitDown, hitDown1, hitDown2 };
        //hit Zombie or boss or items
        if (gameObject.GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            for (int i = 0; i < groupRaycast.Length; ++i)
            {
                if (groupRaycast[i].collider != null)
                {
                    if (groupRaycast[i].collider.tag == "zombie")
                    {
                        playerisHitted();
                        return;
                    }
                    if (groupRaycast[i].collider.tag == "boss")
                    {
                        playerisHitted();
                        return;
                    }
                    if (groupRaycast[i].collider.tag == "shoes")
                    {
                        hitShoes();
                    }
                    if (groupRaycast[i].collider.tag == "multiboom")
                    {
                        hitMultiboom();
                    }
                    if (groupRaycast[i].collider.tag == "boomsize")
                    {
                        hitBoomsize();
                    }
                }
            }
        }
        //Move directions
        //Move Up
        
        if (hitUp1.collider != null)
        {
            if (hitUp1.collider.tag == "Obstacles" || hitUp1.collider.tag=="zombie" || hitUp1.collider.tag=="Rao" || hitUp1.collider.tag=="boss" || hitUp1.collider.tag=="coverItems" || hitUp1.collider.tag=="Player")
                stopUp1 = true;
            else
                stopUp1 = false;
        }
        else
            stopUp1 = false;
        
        if (hitUp2.collider != null)
        {
            if (hitUp2.collider.tag == "Obstacles" || hitUp2.collider.tag == "zombie" || hitUp2.collider.tag == "Rao" || hitUp2.collider.tag == "boss" || hitUp2.collider.tag == "coverItems" || hitUp2.collider.tag == "Player")
                stopUp2 = true;
            else
                stopUp2 = false;
        }
        else
            stopUp2 = false;
        //MoveDown
        
        if (hitDown1.collider != null)
        {
            if (hitDown1.collider.tag == "Obstacles" || hitDown1.collider.tag == "zombie" || hitDown1.collider.tag == "Rao" || hitDown1.collider.tag == "boss" || hitDown1.collider.tag == "coverItems" || hitDown1.collider.tag == "Player")
                stopDown1 = true;
            else
                stopDown1 = false;
        }
        else
            stopDown1 = false;
        
        if (hitDown2.collider != null)
        {
            if (hitDown2.collider.tag == "Obstacles" || hitDown2.collider.tag == "zombie" || hitDown2.collider.tag == "Rao" || hitDown2.collider.tag == "boss" || hitDown2.collider.tag == "coverItems" || hitDown2.collider.tag == "Player")
                stopDown2 = true;
            else
                stopDown2 = false;
        }
        else
            stopDown2 = false;
        //Move Right
       
        if (hitRight1.collider != null)
        {
            if (hitRight1.collider.tag == "Obstacles" || hitRight1.collider.tag == "zombie" || hitRight1.collider.tag == "Rao" || hitRight1.collider.tag == "boss" || hitRight1.collider.tag == "coverItems" || hitRight1.collider.tag == "Player")
                stopRight1 = true;
            else
                stopRight1 = false;
        }
        else
            stopRight1 = false;
        
        if (hitRight2.collider != null)
        {
            if (hitRight2.collider.tag == "Obstacles" || hitRight2.collider.tag == "zombie" || hitRight2.collider.tag == "Rao" || hitRight2.collider.tag == "boss" || hitRight2.collider.tag == "coverItems" || hitRight2.collider.tag == "Player")
                stopRight2 = true;
            else
                stopRight2 = false;
        }
        else
            stopRight2 = false;

        //Move left
        
        if (hitLeft1.collider != null)
        {
            if (hitLeft1.collider.tag == "Obstacles" || hitLeft1.collider.tag == "zombie" || hitLeft1.collider.tag == "Rao" || hitLeft1.collider.tag == "boss" || hitLeft1.collider.tag == "coverItems" || hitLeft1.collider.tag == "Player")
                stopLeft1 = true;
            else
                stopLeft1 = false;
        }
        else
            stopLeft1 = false;
        
        if (hitLeft2.collider != null)
        {
            if (hitLeft2.collider.tag == "Obstacles" || hitLeft2.collider.tag == "zombie" || hitLeft2.collider.tag == "Rao" || hitLeft2.collider.tag == "boss" || hitLeft2.collider.tag == "coverItems" || hitLeft2.collider.tag == "Player")
                stopLeft2 = true;
            else
                stopLeft2 = false;
        }
        else
            stopLeft2 = false;
        

    }
    // Update is called once per frame

    void Update () {
        if (isActive)
        {
            if (timetoMove >= 3f)
            {
                canMove = true;
            }
            else
            {
                timetoMove += Time.deltaTime;
            }

            if (canMove)
            {
                if (Input.GetKey("w"))
                {
                    if (!stopUp1 && !stopUp2)
                    {
                        gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        transform.position -= Vector3.down * speed * Time.deltaTime;
                    }

                }
                else if (Input.GetKey("s"))
                {
                    if (!stopDown1 && !stopDown2)
                    {
                        gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        transform.position -= Vector3.up * speed * Time.deltaTime;
                    }
                }
                else if (Input.GetKey("d"))
                {
                    if (!stopRight1 && !stopRight2)
                    {
                        gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        transform.position -= Vector3.left * speed * Time.deltaTime;
                    }
                }
                else if (Input.GetKey("a"))
                {
                    if (!stopLeft1 && !stopLeft2)
                    {
                        gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        transform.position -= Vector3.right * speed * Time.deltaTime;
                    }
                }
                Flip();
            }
        }
    }
    void playerDie()
    {
        isActive = false;
    }
    public void playerisHitted()
    {
        if (nummberofHeart > 0)
            --nummberofHeart;
        LifeTxt.text = "x " + nummberofHeart;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("isLeft", false);
        anim.SetBool("isDown", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isRevival", true);
        transform.position = new Vector2(-0.5f, -1.5f);
        canMove = false;
        timetoMove = 0f;
        if (nummberofHeart <= 0)
        {
            playerDie();
            GameObject ctl = GameObject.FindGameObjectWithTag("GameController");
            ctl.GetComponent<GameController>().numberofPlayer--;
        }
    }
    void hitBoomsize()
    {
        ++rangeofBoom;
        ++BSize;
        BSizeTxt.text = "x " + BSize;
        GameObject obj = GameObject.FindGameObjectWithTag("boomsize");
        GameObject sound = Instantiate(soundItem, transform.position, Quaternion.identity) as GameObject;
        Destroy(sound, 0.5f);
        Destroy(obj);
    }
    void hitMultiboom()
    {
        ++Bomb;
        BombTxt.text = "x " + Bomb;
        isMultiboom = true;
        GameObject obj = GameObject.FindGameObjectWithTag("multiboom");
        GameObject sound = Instantiate(soundItem, transform.position, Quaternion.identity) as GameObject;
        Destroy(sound, 0.5f);
        Destroy(obj);
    }
    void hitShoes()
    {
        ++Shoe;
        ShoeTxt.text = "x " + Shoe;
        speed += 0.5f;
        GameObject obj = GameObject.FindGameObjectWithTag("shoes");
        GameObject sound = Instantiate(soundItem, transform.position, Quaternion.identity) as GameObject;
        Destroy(sound, 0.5f);
        Destroy(obj);
    }

    void Flip()
    {
        if (Input.GetKey("a"))
        {
            anim.SetBool("isRevival", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
        }
        if (Input.GetKey("d"))
        {
            anim.SetBool("isRevival", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
        }
        if (Input.GetKey("w"))
        {
            anim.SetBool("isRevival", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", true);
        }
        if (Input.GetKey("s"))
        {
            anim.SetBool("isRevival", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", true);
        }
    }
}