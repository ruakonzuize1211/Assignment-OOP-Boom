using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putBomb : MonoBehaviour {
 //   public float destroyTime = 5f;
    public GameObject Bomb2;
    public float keyDelay = 1f;
    private float timePassed = 0f;
    public static GameObject findobject;
	// Use this for initialization
	void Start () {
//        put = false;
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;

        findobject = GameObject.Find("bomb2(Clone)");

        if (Input.GetKey("space") && timePassed >= keyDelay&&findobject==null)
        {
        //    put = true;
          //  Instantiate(Bomb2, new Vector2(Mathf.RoundToInt(transform.position.x)+0.5f, Mathf.RoundToInt(transform.position.y)+0.5f), Quaternion.identity); 
            Instantiate(Bomb2, transform.position, Quaternion.identity);
            timePassed = 0f;
        }
	}
}
