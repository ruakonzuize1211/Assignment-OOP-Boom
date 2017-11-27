using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Button.ButtonType bt;
    public Button()
    { }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.48f, 0.48f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f);
       
        if (bt == Button.ButtonType.btnBack)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene("game");

        }
        if (bt == Button.ButtonType.btnStory)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene("StoryMode");

        }
        if (bt == Button.ButtonType.btnVS)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene("VS mode");

        }
        if (bt == Button.ButtonType.btnLoad)
        {
            SoundController.PlaySound(soundsGame.play);
            SceneManager.LoadScene(PlayerPrefs.GetString("currentlevel"));
            Time.timeScale = 1.0f;

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
        btnStory,
        btnVS,
        btnBack,
        btnLoad,

    }
}

