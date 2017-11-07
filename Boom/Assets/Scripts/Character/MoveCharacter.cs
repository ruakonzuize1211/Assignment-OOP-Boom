using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCharacter : MonoBehaviour {
    public float speed;
    public bool stopUp1, stopDown1, stopRight1, stopLeft1, stopUp2, stopDown2, stopRight2, stopLeft2;
    Transform rayUp1, rayRight1, rayDown1, rayLeft1, rayUp2, rayLeft2, rayDown2, rayRight2;
    void Start () {
        speed = 2f;
        rayUp1 = transform.Find("rayUp1");
        rayRight1 = transform.Find("rayRight1");
        rayDown1 = transform.Find("rayDown1");
        rayLeft1 = transform.Find("rayLeft1");
        rayUp2 = transform.Find("rayUp2");
        rayRight2 = transform.Find("rayRight2");
        rayDown2 = transform.Find("rayDown2");
        rayLeft2 = transform.Find("rayLeft2");
    }
    private void FixedUpdate()
    {
        stopUp1 = Physics2D.Raycast(rayUp1.position, -new Vector2(0, 1f), 0.6f);
        stopDown1 = Physics2D.Raycast(rayDown1.position, new Vector2(0, -1f), 0.6f);
        stopRight1 = Physics2D.Raycast(rayRight1.position,new Vector2(1f,0), 0.6f);
        stopLeft1 = Physics2D.Raycast(rayLeft1.position, new Vector2(-1f, 0), 0.6f);
        stopLeft2 = Physics2D.Raycast(rayLeft2.position, new Vector2(-1f, 0), 0.6f);
        stopUp2 = Physics2D.Raycast(rayUp2.position, -new Vector2(0, 1f), 0.6f);
        stopDown2 = Physics2D.Raycast(rayDown2.position, new Vector2(0, -1f), 0.6f);
        stopRight2 = Physics2D.Raycast(rayRight2.position, new Vector2(1f, 0), 0.6f);
    }
    // Update is called once per frame

    void Update () {
        if (!stopUp1 && !stopUp2)
        {
            if (Input.GetKey("up"))
            {
                transform.position -= Vector3.down * speed * Time.deltaTime;
            }

        }
        if (!stopDown1 && !stopDown2)
        {
            if (Input.GetKey("down"))
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
        }
        if (!stopRight1 && !stopRight2)
        {
            if(Input.GetKey("right"))
            {
                transform.position -= Vector3.left * speed * Time.deltaTime;
            }
        }
        if (!stopLeft1 && !stopLeft2)
        {
            if (Input.GetKey("left"))
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }
        }
    }

}
