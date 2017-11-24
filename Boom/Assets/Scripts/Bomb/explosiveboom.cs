using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveboom : MonoBehaviour
{
    bool canHitboss = true, canHitzombie = true, canhitShoes = true, canHitboomsize = true, canHitmultiboom = true, canHitrao = true, canhitPlayer = true;
    float x, y;
    Vector3 mid, midUp, midDown, midLeft, midRight;
    RaycastHit2D up, up1, up2, down, down1, down2, left, left1, left2, right, right1, right2;
    float distance = 0.5f;
    GameObject controller;
    // Use this for initialization
    void Start()
    {
        controller = GameObject.Find("GameController");
        Destroy(gameObject, 0.5f);
        mid = transform.Find("mid").position;
        midUp = transform.Find("midUp").position;
        midDown = transform.Find("midDown").position;
        midLeft = transform.Find("midLeft").position;
        midRight = transform.Find("midRight").position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        up = Physics2D.Raycast(mid, Vector2.up, distance);
        up1 = Physics2D.Raycast(midLeft, Vector2.up, distance);
        up2 = Physics2D.Raycast(midRight, Vector2.up, distance);
        down = Physics2D.Raycast(mid, Vector2.down, distance);
        down1 = Physics2D.Raycast(midLeft, Vector2.down, distance);
        down2 = Physics2D.Raycast(midRight, Vector2.down, distance);
        left = Physics2D.Raycast(mid, Vector2.left, distance);
        left1 = Physics2D.Raycast(midUp, Vector2.left, distance);
        left2 = Physics2D.Raycast(midDown, Vector2.left, distance);
        right = Physics2D.Raycast(mid, Vector2.right, distance);
        right1 = Physics2D.Raycast(midUp, Vector2.right, distance);
        right2 = Physics2D.Raycast(midDown, Vector2.right, distance);
    }
    void Update()
    {
        RaycastHit2D[,] groupRaycast = new RaycastHit2D[4, 3] { { up, up1, up2 }, { down, down1, down2 }, { left, left1, left2 }, { right, right1, right2 } };
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {

                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "zombie" && canHitzombie)
                {
                    groupRaycast[i, j].transform.GetComponent<zombie>().zombieDie();
                    canHitzombie = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "Player" && canhitPlayer)
                {
                    groupRaycast[i, j].transform.GetComponent<player>().playerisHitted();
                    canhitPlayer = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "boss" && canHitboss)
                {
                    groupRaycast[i, j].transform.GetComponent<BossController>().bosshitBoom();
                    canHitboss = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "Rao" && canHitrao)
                {
                    if(groupRaycast[i,j].collider.GetComponent<Bum>().includeItems==true)
                    {
                        GameController gcl = controller.GetComponent<GameController>();
                        Bum b = groupRaycast[i, j].collider.GetComponent<Bum>();
                        gcl.createItem = true;
                        gcl.boomsize = b.boomsize;
                        gcl.multiboom = b.multiboom;
                        gcl.shoes = b.shoes;
                        gcl.itemPosition = groupRaycast[i, j].transform.position;
                    }
                    Destroy(groupRaycast[i, j].collider);
                    canHitrao = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "shoes" && canhitShoes)
                {
                    groupRaycast[i, j].transform.GetComponent<Animator>().enabled = true;
                    Destroy(groupRaycast[i, j].transform.gameObject, 1f);
                    canhitShoes = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "boomsize" && canHitboomsize)
                {
                    groupRaycast[i, j].transform.GetComponent<Animator>().enabled = true;
                    Destroy(groupRaycast[i, j].transform.gameObject, 1f);
                    canHitboomsize = false;
                    break;
                }
            }
            for (int j = 0; j < 3; ++j)
            {
                if (groupRaycast[i, j].collider != null && groupRaycast[i, j].transform.tag == "multiboom" && canHitmultiboom)
                {
                    groupRaycast[i, j].transform.GetComponent<Animator>().enabled = true;
                    Destroy(groupRaycast[i, j].transform.gameObject, 1f);
                    canHitmultiboom = false;
                    break;
                }
            }
        }
    }
    private void OnDestroy()
    {
        GameObject cnt = GameObject.Find("GameController");
        bool createItem = cnt.GetComponent<GameController>().createItem;
        if(createItem)
        {
            cnt.GetComponent<GameController>().timetoCreateItem = true;
        }
    }
}
