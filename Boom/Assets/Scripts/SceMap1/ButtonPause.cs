using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonPause : MonoBehaviour
{
    public ButtonPause.ButtonType bt;
    public ButtonPause()
    { }
    GameObject Pause1;
    GameObject bomber;

    // Use this for initialization
    void Start()
    {
        
        Pause1 = GameObject.Find("Pause");
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.8f, 0.8f);
        
        if (bt == ButtonPause.ButtonType.SaveBtn)
        {

            PlayerPrefs.SetString("currentlevel", SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            
        }
        if (bt == ButtonPause.ButtonType.ExitBtn)
        {
            SceneManager.LoadScene("game");
        }
        if (bt == ButtonPause.ButtonType.LoadBtn)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("currentlevel"));
            Time.timeScale = 1.0f;
        }
    }


    public enum ButtonType
    {
        ContBtn,
        SaveBtn,
        ExitBtn,
        LoadBtn

    }

}

