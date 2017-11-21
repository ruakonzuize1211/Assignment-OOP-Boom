using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour {
    public int numberofHeart;
    RaycastHit2D hitUp, hitUp1, hitUp2, hitDown, hitDown1, hitDown2, hitLeft, hitLeft1, hitLeft2, hitRight, hitRight1, hitRight2;
    public float speed;
    public bool stopUp1, stopDown1, stopRight1, stopLeft1, stopUp2, stopDown2, stopRight2, stopLeft2;
    public bool ishitZombieup, ishitZombiedown, ishitZombieleft, ishitZombieright;
    Transform rayUp1, rayRight1, rayDown1, rayLeft1, rayUp2, rayLeft2, rayDown2, rayRight2, rayUp, rayDown, rayLeft, rayRight;
    void Start () {
        numberofHeart = 3;
        speed = 2f;
        rayUp1 = transform.Find("rayUp1");
        rayRight1 = transform.Find("rayRight1");
        rayDown1 = transform.Find("rayDown1");
        rayLeft1 = transform.Find("rayLeft1");
        rayUp2 = transform.Find("rayUp2");
        rayRight2 = transform.Find("rayRight2");
        rayDown2 = transform.Find("rayDown2");
        rayLeft2 = transform.Find("rayLeft2");
        rayUp = transform.Find("rayUp");
        rayRight = transform.Find("rayRight");
        rayDown = transform.Find("rayDown");
        rayLeft = transform.Find("rayLeft");
    }
    private void FixedUpdate()
    {
        //hit Zombie
        hitUp = Physics2D.Raycast(rayUp.position, new Vector2(0, 1f), 0.1f);
        if (hitUp.collider != null)
        {
           if(hitUp.collider.tag=="zombie")
            {
                playerDie();
            }
        }
        hitDown = Physics2D.Raycast(rayDown.position, new Vector2(0, 1f), 0.1f);
        if (hitDown.collider != null)
        {
            if (hitDown.collider.tag == "zombie")
            {
                playerDie();
            }
        }
        hitRight = Physics2D.Raycast(rayRight.position, new Vector2(0, 1f), 0.1f);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "zombie")
            {
                playerDie();
            }
        }
        hitLeft = Physics2D.Raycast(rayLeft.position, new Vector2(0, 1f), 0.1f);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "zombie")
            {
                playerDie();
            }
        }
        //Move Up
        hitUp1 = Physics2D.Raycast(rayUp1.position, new Vector2(0, 1f), 0.1f);
        if (hitUp1.collider != null)
        {
            if (hitUp1.collider.tag == "Obstacles" || hitUp1.collider.tag=="zombie" || hitUp1.collider.tag=="Rao")
                stopUp1 = true;
            else
                stopUp1 = false;
        }
        else
            stopUp1 = false;
        hitUp2 = Physics2D.Raycast(rayUp2.position, new Vector2(0, 1f), 0.1f);
        if (hitUp2.collider != null)
        {
            if (hitUp2.collider.tag == "Obstacles" || hitUp2.collider.tag == "zombie" || hitUp2.collider.tag == "Rao")
                stopUp2 = true;
            else
                stopUp2 = false;
        }
        else
            stopUp2 = false;
        //MoveDown
        hitDown1 = Physics2D.Raycast(rayDown1.position, new Vector2(0, -1f), 0.1f);
        if (hitDown1.collider != null)
        {
            if (hitDown1.collider.tag == "Obstacles" || hitDown1.collider.tag == "zombie" || hitDown1.collider.tag == "Rao")
                stopDown1 = true;
            else
                stopDown1 = false;
        }
        else
            stopDown1 = false;
        hitDown2 = Physics2D.Raycast(rayDown2.position, new Vector2(0, -1f), 0.1f);
        if (hitDown2.collider != null)
        {
            if (hitDown2.collider.tag == "Obstacles" || hitDown2.collider.tag == "zombie" || hitDown2.collider.tag == "Rao")
                stopDown2 = true;
            else
                stopDown2 = false;
        }
        else
            stopDown2 = false;
        //Move Right
        hitRight1 = Physics2D.Raycast(rayRight1.position,new Vector2(1f,0), 0.5f);
        if (hitRight1.collider != null)
        {
            if (hitRight1.collider.tag == "Obstacles" || hitRight1.collider.tag == "zombie" || hitRight1.collider.tag == "Rao")
                stopRight1 = true;
            else
                stopRight1 = false;
        }
        else
            stopRight1 = false;
        hitRight2 = Physics2D.Raycast(rayRight2.position, new Vector2(1f, 0), 0.5f);
        if (hitRight2.collider != null)
        {
            if (hitRight2.collider.tag == "Obstacles" || hitRight2.collider.tag == "zombie" || hitRight2.collider.tag == "Rao")
                stopRight2 = true;
            else
                stopRight2 = false;
        }
        else
            stopRight2 = false;

        //Move left
        hitLeft1 = Physics2D.Raycast(rayLeft1.position, new Vector2(-1f, 0), 0.5f);
        if (hitLeft1.collider != null)
        {
            if (hitLeft1.collider.tag == "Obstacles" || hitLeft1.collider.tag == "zombie" || hitLeft1.collider.tag == "Rao")
                stopLeft1 = true;
            else
                stopLeft1 = false;
        }
        else
            stopLeft1 = false;
        hitLeft2 = Physics2D.Raycast(rayLeft2.position, new Vector2(-1f, 0), 0.5f);
        if (hitLeft2.collider != null)
        {
            if (hitLeft2.collider.tag == "Obstacles" || hitLeft2.collider.tag == "zombie" || hitLeft2.collider.tag == "Rao")
                stopLeft2 = true;
            else
                stopLeft2 = false;
        }
        else
            stopLeft2 = false;
        

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
    void playerDie()
    {
        Debug.Log("die cause zombie hits");
    }
    public void playerisHitted()
    {
        --numberofHeart;
        if (numberofHeart == 0)
            playerDie();
    }
}
