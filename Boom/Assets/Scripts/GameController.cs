using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public bool bossActive = false;
    public int numbersZombie;
	// Use this for initialization
	void Start () {
        numbersZombie = 1;
        bossActive = false;
	}
	
	// Update is called once per frame
	void Update () {

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
            bossActive = true;
            destroyallObstacles();
        }
    }
}
