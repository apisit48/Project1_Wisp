using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image HealthBar;
    Animator myAnimator;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        myAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health/maxHealth,0,1);
        if(health <= 0 ){
            myAnimator.SetTrigger("isDying");
        }
        
    }
}
