using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonOP : MonoBehaviour
{
    public ButtonOP.ButtonType bt;
    public ButtonOP()
    { }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f);

        if (bt == ButtonOP.ButtonType.btnBack)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene("game");

        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public enum ButtonType
    {
        btnBack,
        btnSound,
        btnControl,
        btnLevel

    }
}


