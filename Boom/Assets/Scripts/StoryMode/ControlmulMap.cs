using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class ControlmulMap : MonoBehaviour
{
    public GameObject Map1, Map2, Text1, Text2;
    
    float x, y, z,x1,y1,z1;
    bool find;
    // Use this for initialization
    void Start()
    {

        x = Map1.transform.position.x;
        y = Map1.transform.position.y;
        z = Map1.transform.position.z;
        x1 = Map2.transform.position.x;
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Map1.transform.position = new Vector3(Map1.transform.position.x - 7, Map1.transform.position.y, Map1.transform.position.z);
            Map2.transform.position = new Vector3(Map2.transform.position.x - 7, Map2.transform.position.y, Map2.transform.position.z);
            Text1.transform.position = new Vector3(Text1.transform.position.x - 7, Text1.transform.position.y, Text1.transform.position.z);
            Text2.transform.position = new Vector3(Text2.transform.position.x - 7, Text2.transform.position.y, Text2.transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Map1.transform.position = new Vector3(Map1.transform.position.x + 7, Map1.transform.position.y, Map1.transform.position.z);
            Map2.transform.position = new Vector3(Map2.transform.position.x + 7, Map2.transform.position.y, Map2.transform.position.z);
            Text1.transform.position = new Vector3(Text1.transform.position.x + 7, Text1.transform.position.y, Text1.transform.position.z);
            Text2.transform.position = new Vector3(Text2.transform.position.x + 7, Text2.transform.position.y, Text2.transform.position.z);

        }
        if (Mathf.Abs(Map1.transform.position.x- x) <= 0.01 && Mathf.Abs(Map1.transform.position.y - y) <= 0.01 && Mathf.Abs(Map1.transform.position.z - z) <= 0.01)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("mulMap1");

            }

        }
        if (Map2.transform.position.x <x1 && Map2.transform.position.x > -5.0)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("mulMap2");

            }

        }

    }
}










    

    
   
