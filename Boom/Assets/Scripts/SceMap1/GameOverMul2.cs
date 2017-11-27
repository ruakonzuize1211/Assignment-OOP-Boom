using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMul2 : MonoBehaviour {
    public GameOver2.ButtonType bt;
   
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f);

        if (bt == GameOver2.ButtonType.btnBackToMenu)
        {
            
            SceneManager.LoadScene("game");

        }
        if (bt == GameOver2.ButtonType.btnRestart)
        {

            SceneManager.LoadScene("mulMap2");

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
        btnBackToMenu,
        btnRestart


    }
}
