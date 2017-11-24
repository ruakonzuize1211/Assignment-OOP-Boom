using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public bool bossActive = false;
    public int numbersZombie = 1;
    //variable for create items
    public GameObject newBoomsize, newMultiboom, newShoes;
    public Vector2 itemPosition;
    public bool timetoCreateItem = false;
    public bool createItem = false;
    public bool boomsize = false, multiboom = false, shoes = false;
    // Use this for initialization
    void Start () {
        numbersZombie = 1;
        bossActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(timetoCreateItem)
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
        if(numbersZombie<=0)
        {
            bossCome();
        }
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
}
