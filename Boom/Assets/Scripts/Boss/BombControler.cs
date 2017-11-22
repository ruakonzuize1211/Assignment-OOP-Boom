using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControler : MonoBehaviour {
    public bool throwbyBoss = false;
    public Vector3 target;
    public float moveSpeed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (throwbyBoss)
            transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);//Xác định vị trí của nhân vật để ném bom
	}
}
