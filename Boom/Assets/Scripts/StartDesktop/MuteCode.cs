using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteCode : MonoBehaviour {
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
            audioSource.mute = !audioSource.mute;
    }
}
