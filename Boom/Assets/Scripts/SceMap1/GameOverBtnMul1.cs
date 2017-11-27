using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBtnMul1 : MonoBehaviour {
    public GameOverBtn.ButtonType bt;
   
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f);

        if (bt == GameOverBtn.ButtonType.btnBackToMenu)
        {
            
            SceneManager.LoadScene("game");

        }
        if (bt == GameOverBtn.ButtonType.btnRestart)
        {

            SceneManager.LoadScene("mulMap1");

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
