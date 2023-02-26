using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 4.0f;
    [SerializeField] TrailRenderer tr;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    Vector2 moveInput;
    Rigidbody2D rgbd2D;

    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    CircleCollider2D myCircleCollider;
    float gravityScaleAtStart;
    bool doubleJump;
    bool isAlive = true;



    void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        gravityScaleAtStart = rgbd2D.gravityScale;
    }

    void Update()
    {   
        if(!isAlive) { return; };
        Run();
        FlipSprite();
        Die();
    }

    void OnFire(InputValue value)
    {
        if(!isAlive) { return; };
        Instantiate(bullet, gun.position, transform.rotation);
        myAnimator.SetTrigger("Shoot");

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }


    void OnJump(InputValue value)
    {   

        if(myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !value.isPressed){
            doubleJump  = false;
        }

        if(value.isPressed)
        {
            if(myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || doubleJump){
                rgbd2D.velocity += new Vector2 (rgbd2D.velocity.x, jumpSpeed);    
                doubleJump = !doubleJump;
            }
                
        }

        if(value.isPressed && rgbd2D.velocity.y > 0f )
        {
            rgbd2D.velocity += new Vector2 (rgbd2D.velocity.x, jumpSpeed * 0.5f);    
        }
    }

    void Die() 
    {
        if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards","EnemyBullets")))
        {
            isAlive = false;
            myAnimator.SetTrigger("isDying");
            StartCoroutine(informGameSession());
        }    
    }
    
    IEnumerator informGameSession()
    {
        yield return new WaitForSecondsRealtime(1f); 
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed , rgbd2D.velocity.y);
        rgbd2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rgbd2D.velocity.x) >  Mathf.Epsilon;
        if(playerHasHorizontalSpeed) 
        {
            myAnimator.SetBool("isRunning", true);

        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void FlipSprite()
    {
        bool playHasHorizontalSpeed = Mathf.Abs(rgbd2D.velocity.x) > Mathf.Epsilon; 
        if(playHasHorizontalSpeed) 
        {
            transform.localScale = new Vector2 (Mathf.Sign(rgbd2D.velocity.x), 1f);
        }
    }




}
