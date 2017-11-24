using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bum : MonoBehaviour {
    public GameObject boxbum;
    public bool includeItems = false, boomsize = false, multiboom = false, shoes = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Collider2D>()==null)
        {
            GameObject obj = Instantiate(boxbum, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(obj, 1f);
        }      
   }
}
