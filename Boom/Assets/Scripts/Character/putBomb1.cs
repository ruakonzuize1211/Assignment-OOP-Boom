using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putBomb1 : MonoBehaviour {
    //   public float destroyTime = 5f;
    GameObject gameController;
    public GameObject Bomb2;
    public float keyDelay = 1f;
    private float timePassed = 0f;
    public static GameObject findobject;
    private float x1, x2, y1, y2, subx, suby;
    bool isBossactive;
    public bool isMultiboom = false;
    // Use this for initialization



    void Start () {
        gameController = GameObject.Find("GameController");
                
	}
    
   
	// Update is called once per frame
	void Update () {
        isMultiboom = gameObject.GetComponentInParent<player1>().isMultiboom;
        timePassed += Time.deltaTime;

        findobject = GameObject.Find("boom(Clone)");

        if (Input.GetKey(KeyCode.Return) && ((timePassed >= keyDelay && findobject == null) || (isMultiboom == true && timePassed >= keyDelay)))
        {
            subx = transform.position.x - (float)Mathf.RoundToInt(transform.position.x);//>0 khi toa do lam tron nho hon
            suby = transform.position.y - (float)Mathf.RoundToInt(transform.position.y);
            x1 = Mathf.RoundToInt(transform.position.x) + 0.5f;
            x2 = Mathf.RoundToInt(transform.position.x) - 0.5f;
            y1 = Mathf.RoundToInt(transform.position.y) + 0.5f;
            y2 = Mathf.RoundToInt(transform.position.y) - 0.5f;
            if (subx > 0.0f && suby > 0.0f)
            {
                Instantiate(Bomb2, new Vector2(x1, y1), Quaternion.identity);
            }
            if (subx > 0.0f && suby < 0.0f)
            {
                Instantiate(Bomb2, new Vector2(x1, y2), Quaternion.identity);
            }
            if (subx < 0.0f && suby > 0.0f)
            {
                Instantiate(Bomb2, new Vector2(x2, y1), Quaternion.identity);
            }
            if (subx < 0.0f && suby < 0.0f)
            {
                Instantiate(Bomb2, new Vector2(x2, y2), Quaternion.identity);
            }
            timePassed = 0f;
        }
	}
}
