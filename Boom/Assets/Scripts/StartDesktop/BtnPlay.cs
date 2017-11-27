using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnPlay : MonoBehaviour {
    public BtnPlay.ButtonType bt;
    public BtnPlay()
    { }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.75f, 0.75f);
        if (bt == BtnPlay.ButtonType.Playbtn)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene("PlayMode");

        }
        if (bt == BtnPlay.ButtonType.Optionbtn)
        {
            SoundController.PlaySound(soundsGame.option);
            SceneManager.LoadScene("OptionMode");

        }
        if (bt == BtnPlay.ButtonType.Aboutbtn)
        {
            SoundController.PlaySound(soundsGame.about);
            SceneManager.LoadScene("AboutMode 1");

        }
        if (bt == BtnPlay.ButtonType.Exitbtn)
        {
            SoundController.PlaySound(soundsGame.exit);
            Application.Quit();

        }
        if (bt == BtnPlay.ButtonType.Guidebtn)
        {
            SoundController.PlaySound(soundsGame.exit);
            SceneManager.LoadScene("Guide");

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
        Playbtn,
        Optionbtn,
        Aboutbtn,
        Exitbtn,
        Guidebtn

    }
}
