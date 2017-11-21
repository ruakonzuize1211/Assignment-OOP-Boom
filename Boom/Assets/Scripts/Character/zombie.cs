using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour {
    public int countTime;
    public GameObject mainPlayer;
    public enum direction { up, right, down, left,multidir };
    RaycastHit2D hitUp, hitUp1, hitUp2, hitDown, hitDown1, hitDown2, hitLeft, hitLeft1, hitLeft2, hitRight, hitRight1, hitRight2;
    direction lastDirection, repeatDirection;
    public float speed;
    public bool stopUp, stopUp1, stopUp2, stopDown, stopDown1, stopDown2, stopRight, stopRight1, stopRight2, stopLeft, stopLeft1, stopLeft2;
    Transform rayUp1, rayRight1, rayDown1, rayLeft1, rayUp2, rayLeft2, rayDown2, rayRight2, rayUp, rayRight, rayDown, rayLeft;
    GameObject controller;
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("GameController");
        countTime = 0;
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        lastDirection = direction.up;
        repeatDirection = direction.multidir;
        speed = 1.5f;
        rayUp = transform.Find("rayUp");
        rayRight = transform.Find("rayRight");
        rayDown = transform.Find("rayDown");
        rayLeft = transform.Find("rayLeft");
        rayUp1 = transform.Find("rayUp1");
        rayRight1 = transform.Find("rayRight1");
        rayDown1 = transform.Find("rayDown1");
        rayLeft1 = transform.Find("rayLeft1");
        rayUp2 = transform.Find("rayUp2");
        rayRight2 = transform.Find("rayRight2");
        rayDown2 = transform.Find("rayDown2");
        rayLeft2 = transform.Find("rayLeft2");
    }
	
	// Update is called once per frame
	private void FixedUpdate () {
        //Move Up
        hitUp = Physics2D.Raycast(rayUp.position, new Vector2(0, 1f), 0.1f);
        if (hitUp.collider != null)
        {
            if (hitUp.collider.tag == "Obstacles" || hitUp.collider.tag == "zombie" || hitUp.collider.tag=="Rao")
                stopUp = true;
            else
                stopUp = false;
        }
        else
            stopUp = false;
        hitUp1 = Physics2D.Raycast(rayUp1.position, new Vector2(0, 1f), 0.1f);
        if (hitUp1.collider != null)
        {
            if (hitUp1.collider.tag == "Obstacles" || hitUp1.collider.tag == "zombie" || hitUp1.collider.tag == "Rao")
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
        hitDown = Physics2D.Raycast(rayDown.position, new Vector2(0, -1f), 0.1f);
        if (hitDown.collider != null)
        {
            if (hitDown.collider.tag == "Obstacles" || hitDown.collider.tag == "zombie" || hitDown.collider.tag == "Rao")
                stopDown = true;
            else
                stopDown = false;
        }
        else
            stopDown = false;
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
        hitRight = Physics2D.Raycast(rayRight.position, new Vector2(1f, 0), 0.1f);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Obstacles" || hitRight.collider.tag == "zombie" || hitRight.collider.tag == "Rao")
                stopRight = true;
            else
                stopRight = false;
        }
        else
            stopRight = false;
        hitRight1 = Physics2D.Raycast(rayRight1.position, new Vector2(1f, 0), 0.5f);
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
        hitLeft = Physics2D.Raycast(rayLeft.position, new Vector2(-1f, 0), 0.1f);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Obstacles" || hitLeft.collider.tag == "zombie" || hitLeft.collider.tag == "Rao")
                stopLeft = true;
            else
                stopLeft = false;
        }
        else
            stopLeft = false;
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
    void Update()
    {
        if (countTime > 180)
        {
            countTime = 0;
            repeatDirection = direction.multidir;
        }
        Vector3 playerPosition = mainPlayer.transform.position;
        if (Input.GetKey("up"))
        {
            if (!stopUp && !stopUp1 && !stopUp2 && repeatDirection!=direction.up)
            {
                moveUp();
            }
            else
            {
                autoMove(direction.up);
                repeatDirection = direction.up;
                ++countTime;
            }
        }
        else if (Input.GetKey("down"))
        {
            if (!stopDown && !stopDown1 && !stopDown2 && repeatDirection!=direction.down)
            {
                moveDown();
            }
            else
            {
                autoMove(direction.down);
                repeatDirection = direction.down;
                ++countTime;
            }
        }
        else if (Input.GetKey("left"))
        {
            if (!stopLeft && !stopLeft1 && !stopLeft2 && repeatDirection!=direction.left)
            {
                moveLeft();
            }
            else
            {
                autoMove(direction.left);
                repeatDirection = direction.left;
                ++countTime;
            }
        }
        else if (Input.GetKey("right"))
        {
            if (!stopRight && !stopRight1 && !stopRight2 && repeatDirection!=direction.right)
            {
                moveRight();
            }
            else
            {
                autoMove(direction.right);
                repeatDirection = direction.right;
                ++countTime;
            }
        }
        else
        {
            autoMove(direction.multidir);
        }
    }
    void moveRight()
    {
        transform.position -= Vector3.left * speed * Time.deltaTime;
    }
    void moveLeft()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }
    void moveUp()
    {
        transform.position -= Vector3.down * speed * Time.deltaTime;
    }
    void moveDown()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }
    void autoMove(direction except)
    {
        if (lastDirection == direction.up && !stopUp1 && !stopUp2 && !stopUp)
        {
            moveUp();
            return;
        }
        else if (lastDirection == direction.right && !stopRight1 && !stopRight2 && !stopRight)
        {
            moveRight();
            return;
        }
        else if (lastDirection == direction.down && !stopDown1 && !stopDown2 && !stopDown)
        {
            moveDown();
            return;
        }
        else if (lastDirection == direction.left && !stopLeft1 && !stopLeft2 && !stopLeft)
        {
            moveLeft();
            return;
        }
        List<direction> temp = new List<direction>();
        if (!stopUp && !stopUp1 && !stopUp2 && except != direction.up)
            temp.Add(direction.up);
        if (!stopRight && !stopRight1 && !stopRight2 && except != direction.right)
            temp.Add(direction.right);
        if (!stopDown && !stopDown1 && !stopDown2 && except != direction.down)
            temp.Add(direction.down);
        if (!stopLeft && !stopLeft1 && !stopLeft2 && except != direction.left)
            temp.Add(direction.left);
        if (temp.Count > 0)
        {
            int rnd = Random.Range(0, temp.Count);
            if (temp[rnd] == direction.up)
            {
                moveUp();
                lastDirection = direction.up;
            }
            else if (temp[rnd] == direction.right)
            {
                moveRight();
                lastDirection = direction.right;
            }
            else if (temp[rnd] == direction.left)
            {
                moveLeft();
                lastDirection = direction.left;
            }
            else if (temp[rnd] == direction.down)
            {
                moveDown();
                lastDirection = direction.down;
            }
        }
    }
    public void zombieDie()
    {
        Destroy(gameObject);
        controller.GetComponent<GameController>().zombieDie();
    }
}
