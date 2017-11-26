using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinBtn : MonoBehaviour {
    public YouWinBtn.ButtonType bt;

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f);

        if (bt == YouWinBtn.ButtonType.btnNextLevel)
        {

            SceneManager.LoadScene("SceMap2");

        }
    }   
        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public enum ButtonType
    {
        
        btnNextLevel

    }
}
