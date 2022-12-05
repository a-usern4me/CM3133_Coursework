using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyScript : MonoBehaviour {
    private float time = 1.0f;

    Animator anim;
    public Rigidbody2D myRigid;
    private ParticleSystem myPart;
    
    void Start(){
        myRigid = this.GetComponent<Rigidbody2D>();
        myPart = this.GetComponent<ParticleSystem>();
        anim = this.GetComponent<Animator>();

        myRigid.AddForce(Vector3.left * 300);
        
    }
    
    void Update(){
        time -= Time.deltaTime;

        if (Input.GetKey("a") && time <= 0f){
            time = 1.0f;

        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && time <= 0.0){
            anim.Play("newEnemyAttack");
            myRigid.AddForce(Vector3.left * 200);
        
        }

        if (collision.gameObject.tag == "Player" && time >= 0.5){
            myRigid.velocity = Vector3.zero;
            anim.Play("newEnemyDamaged");
            myPart.Play();
                
        }

    }
 
}