using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {
    public GameObject BossHealthCanvas;
    public float maxHealth=100;
    float currHealth;
    private Animator anim;
    public Slider BossHealthSlider;//Thanh máu UI
	// Use this for initialization
	void Start () {
        currHealth = maxHealth;
        BossHealthSlider.maxValue = maxHealth;
        BossHealthSlider.value = maxHealth;
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddDamge(float damage)
    {
        currHealth -= damage; //Máu giảm theo lượng damage do bom gây ra
        BossHealthSlider.value = currHealth; //Thanh máu giảm
        if (BossHealthSlider.value <= 0) MakeDead();//Chết
    }

    void MakeDead()
    {
        Destroy(BossHealthCanvas);
        anim.SetBool("isDie", true);
        Destroy(gameObject,3f);
    }
}
