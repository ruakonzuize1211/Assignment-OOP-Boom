using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controler : MonoBehaviour {

    public GameObject bomb;
    public float minBombTime = 2;
    public float maxBombTime = 4;
    private float bombTime = 0;
    private float lastBombTime = 0;
    public float throughBombTime = 0.5f;
    private GameObject Bomber;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        UpdateBombTime();
        Bomber = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBomb", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBombTime + bombTime - throughBombTime)
        {
            anim.SetBool("isBomb", true);
        }
        if (Time.time >= lastBombTime + bombTime)
        {
            ThroughBomb();
        }
    }

    void UpdateBombTime()
    {
        lastBombTime = Time.time;
        bombTime = Random.Range(minBombTime, maxBombTime + 1);
    }

    void ThroughBomb()
    {
        GameObject bom = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;
        if (Bomber.transform.position.x > 0)
        {
            bom.GetComponent<BombControler>().target.x = Random.Range(-5, -4);
        }
        else
        {
            bom.GetComponent<BombControler>().target.x = Random.Range(4, 5);
        }
        bom.GetComponent<BombControler>().target.y = Random.Range(0, 1);
        UpdateBombTime();
        anim.SetBool("isBomb", false);
    }
}
