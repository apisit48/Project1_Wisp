using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBulletScript : MonoBehaviour
{
    PlayerMovement player;
    // private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float timer;

     public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // player = GameObject.FindGameObjectWithTag("Player");
        player = FindObjectOfType<PlayerMovement>();
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;
        float rot =Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot +90);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer > 10){
            Destroy(gameObject);
        }
        
    }

    // void OnTriggerEnter2D(Collider2D other){
    //     if(other.tag == "Player"){
    //         Destroy(other.gameObject);
    //     }
    // }
    // void OnCollisionEnter2D(Collider2D other){
    //     if(other.tag == "Player"){
    //         other.gameObject.GetComponent<PlayerHealth>().health -= damage;
    //         Destroy(gameObject);
    //     }
    // }
}
