using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlant : MonoBehaviour
{
    public int health;
    public int damage;
    Animator myAnimator;
    Rigidbody2D rgbd2D;
    CapsuleCollider2D myCapsuleCollider;




    // Start is called before the first frame update
    void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        health = 1000;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
