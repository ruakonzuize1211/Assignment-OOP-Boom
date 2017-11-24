using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createItems : MonoBehaviour {
    public GameObject newBoomsize, newMultiboom, newShoes;
    GameObject boomsize, multiboom, shoes;
	// Use this for initialization
	void Start () {
        boomsize = GameObject.FindGameObjectWithTag("multiboom");
        multiboom = GameObject.FindGameObjectWithTag("boomsize");
        shoes = GameObject.FindGameObjectWithTag("shoes");
	}

    // Update is called once per frame
    void Update()
    {
    }
    public void createItemsforBox()
    {
        //if (gameObject.GetComponent<Collider2D>() == null)
        //{
            if (boomsize == null)
            {
                GameObject obj = Instantiate(newBoomsize, transform.position, Quaternion.identity) as GameObject;
            }
            else if (shoes == null)
            {
                GameObject obj = Instantiate(newShoes, transform.position, Quaternion.identity) as GameObject;
            }
            else if (multiboom == null)
            {
                GameObject obj = Instantiate(newMultiboom, transform.position, Quaternion.identity) as GameObject;
            }
        //}
    }
}
