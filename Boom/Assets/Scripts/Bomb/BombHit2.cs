using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHit2 : MonoBehaviour {
    //Những cái để dạng comment để dành khi làm màn hình kết thúc nha Ánh
    GameObject player;
    public GameObject explosionPrefab;
    const float TIME_TO_WAIT = 2f;
    float timeWaitPassed = 0;
    bool bWaiting = false;
    public int rangeofBoom = 1;
    //raycast bốn phía kiểm tra vật cản
    Transform rayUp1, rayRight1, rayDown1, rayLeft1, rayUp2, rayLeft2, rayDown2, rayRight2, rayUp, rayDown, rayLeft, rayRight;
    // Use this for initialization
    void Start() {
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
        player = GameObject.Find("bomber2");
        bWaiting = true;
        timeWaitPassed = 0;
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        rangeofBoom = player.GetComponent<player2>().rangeofBoom;
        if (bWaiting)   //update wait time
        {
            timeWaitPassed += Time.deltaTime;   //increase time
            Destroy(gameObject, 2f);
            if (timeWaitPassed > TIME_TO_WAIT)
            {
                bWaiting = false;
                timeWaitPassed = 0;
                GameObject obj = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
                Destroy(obj, 0.5f);
                Vector3 boomPosition = transform.position;
                for (int i = 1; i <= rangeofBoom; ++i)
                {
                    float dis = i - 0.5f * i;
                    RaycastHit2D hitup = Physics2D.Raycast(rayUp.position, Vector2.up, dis, 1);
                    RaycastHit2D hitdown = Physics2D.Raycast(rayDown.position, Vector2.down, dis, 1);
                    RaycastHit2D hitright = Physics2D.Raycast(rayRight.position, Vector2.right, dis, 1);
                    RaycastHit2D hitleft = Physics2D.Raycast(rayLeft.position, Vector2.left, dis, 1);
                    RaycastHit2D hitup1 = Physics2D.Raycast(rayUp.position, Vector2.up, dis, 1);
                    RaycastHit2D hitdown1 = Physics2D.Raycast(rayDown.position, Vector2.down, dis, 1);
                    RaycastHit2D hitright1 = Physics2D.Raycast(rayRight.position, Vector2.right, dis, 1);
                    RaycastHit2D hitleft1 = Physics2D.Raycast(rayLeft.position, Vector2.left, dis, 1);
                    RaycastHit2D hitup2 = Physics2D.Raycast(rayUp.position, Vector2.up, dis, 1);
                    RaycastHit2D hitdown2 = Physics2D.Raycast(rayDown.position, Vector2.down, dis, 1);
                    RaycastHit2D hitright2 = Physics2D.Raycast(rayRight.position, Vector2.right, dis, 1);
                    RaycastHit2D hitleft2 = Physics2D.Raycast(rayLeft.position, Vector2.left, dis, 1);
                    //Bomb bắt đầu nổ
                    if (hitdown.collider == null && hitdown1.collider == null && hitdown2.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y - i), Quaternion.identity) as GameObject;
                    }
                    if (hitup.collider == null && hitup1.collider == null && hitup2.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y + i), Quaternion.identity) as GameObject;
                 

                    }
                    if (hitright.collider == null && hitright1.collider == null && hitright2.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x + i, boomPosition.y), Quaternion.identity) as GameObject;
                       
                    }
                    if (hitleft.collider == null && hitleft1.collider == null && hitleft2.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x - i, boomPosition.y), Quaternion.identity) as GameObject;
                        
                    }
                    //Check is this not Obstacles
                    bool down = (hitdown.collider == null || (hitdown.collider != null && hitdown.collider.tag != "Obstacles")) && (hitdown1.collider == null || (hitdown1.collider != null && hitdown1.collider.tag != "Obstacles")) && (hitdown2.collider == null || (hitdown2.collider != null && hitdown2.collider.tag != "Obstacles"));
                    bool up = (hitup.collider == null || (hitup.collider != null && hitup.collider.tag != "Obstacles")) && (hitup1.collider == null || (hitup1.collider != null && hitup1.collider.tag != "Obstacles")) && (hitup2.collider == null || (hitup2.collider != null && hitup2.collider.tag != "Obstacles"));
                    bool left = (hitleft.collider == null || (hitleft.collider != null && hitleft.collider.tag != "Obstacles")) && (hitleft1.collider == null || (hitleft1.collider != null && hitleft1.collider.tag != "Obstacles")) && (hitleft2.collider == null || (hitleft2.collider != null && hitleft2.collider.tag != "Obstacles"));
                    bool right = (hitright.collider == null || (hitright.collider != null && hitright.collider.tag != "Obstacles")) && (hitright1.collider == null || (hitright1.collider != null && hitright1.collider.tag != "Obstacles")) && (hitright2.collider == null || (hitright2.collider != null && hitright2.collider.tag != "Obstacles"));
                    if (down)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y - i), Quaternion.identity) as GameObject;
                       
                    }
                    if (up)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y + i), Quaternion.identity) as GameObject;
                       

                    }
                    if (right)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x + i, boomPosition.y), Quaternion.identity) as GameObject;
                      
                    }
                    if (left)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x - i, boomPosition.y), Quaternion.identity) as GameObject;
                       
                    }
                }
            }
        }
    }
}
