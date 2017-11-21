using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControler : MonoBehaviour {
    public float moveSpeed = 5;
    public Vector3 target;
    public bool boomfromBoss = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (boomfromBoss)
            transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1); //Xác định vị trí của nhân vật để ném bom
    }
}
