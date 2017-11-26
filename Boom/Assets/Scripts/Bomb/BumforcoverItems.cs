using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumforcoverItems : MonoBehaviour {
    public bool includeItems = false, boomsize = false, multiboom = false, shoes = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Collider2D>()==null)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 1f);
        }      
   }
}
