using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int numberofPlayer = 2;
    public bool bossActive = false;
    public int numbersZombie = 7;
    GameObject GameOver;
    //variable for create items
    public GameObject newBoomsize, newMultiboom, newShoes;
    public Vector2 itemPosition;
    public bool timetoCreateItem = false;
    public bool createItem = false;
    public bool boomsize = false, multiboom = false, shoes = false;
    //for boss
    public GameObject YouWin, btnWin;
    // Use this for initialization
    void Start () {
        GameOver = GameObject.Find("You_lose");
        GameOver.SetActive(false);
        bossActive = false;
        YouWin = GameObject.Find("You_win");
        btnWin = GameObject.Find("NEXT LEVEL");
        YouWin.SetActive(false);
        btnWin.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player==null || numberofPlayer<=0)
        {
            allPlayersDie();
        }
        GameObject zombie = GameObject.FindGameObjectWithTag("zombie");
        if(zombie==null)
        {
            bossCome();
        }
        GameObject boss = GameObject.FindGameObjectWithTag("boss");
        if(boss==null)
        {
            YouWin.SetActive(true);
            btnWin.SetActive(true);
        }
        if (timetoCreateItem)
        {
            makeItem();
        }
	}
    void destroyallObstacles()
    {
        GameObject obstacles = GameObject.Find("Barriers");
        Destroy(obstacles);
        GameObject coverItem = GameObject.Find("CoverItem");
        Destroy(coverItem);
    }
    public void zombieDie()
    {
        --numbersZombie;
        //if(numbersZombie<=0)
        //{
            //bossCome();
        //}
    }
    void bossCome()
    {
        bossActive = true;
        destroyallObstacles();
    }
    void makeItem()
    {
        if(multiboom==true)
        {
            GameObject obj = Instantiate(newMultiboom, itemPosition, Quaternion.identity) as GameObject;
        }
        else if (shoes == true)
        {
            GameObject obj = Instantiate(newShoes, itemPosition, Quaternion.identity) as GameObject;
        }
        else if (boomsize == true)
        {
            GameObject obj = Instantiate(newBoomsize, itemPosition, Quaternion.identity) as GameObject;
        }
        createItem = false;
        timetoCreateItem = false;
    }
    public void allPlayersDie()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
