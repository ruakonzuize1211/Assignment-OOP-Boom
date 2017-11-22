using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PMenu : MonoBehaviour
{
    
    public PMenu()
    { }

    GameObject Pause;
    bool p;
    [SerializeField]
    // Use this for initialization
    void Start()
    {
        p = false;
        Pause = GameObject.Find("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            p = !p;
        }
        if (p)
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
        if(!p)
        {
            Pause.SetActive(false);
            Time.timeScale = 1;
        }

    }
   
      
       


}

