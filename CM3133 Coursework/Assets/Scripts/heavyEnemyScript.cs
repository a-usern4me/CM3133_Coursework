using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyEnemyScript : MonoBehaviour {
    private float guardTime = 1.0f;
    public float rollTime = 1.0f;
    private bool vulnerable = false;
    public float vulnerableTime = 0;

    Animator anim;
    public Rigidbody2D myRigid;
    private ParticleSystem myPart;
    public heavyAmountManager hsm;
    
    void Start(){
        myRigid = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        myRigid.AddForce(Vector3.left * 150);
        
    }
    
    void Update(){
        guardTime -= Time.deltaTime;
        rollTime -= Time.deltaTime;
        vulnerableTime -= Time.deltaTime;

        if (Input.GetKey("a") && guardTime <= 0f){
            guardTime = 1.0f;

        }

        if (Input.GetKey("d") && rollTime <= 0f){
            rollTime = 1.0f;

        }
    
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            if (vulnerable == false){
                if (guardTime >= 0.5){
                    myRigid.velocity = Vector3.zero;
                    anim.Play("heavyDamaged");
                    vulnerable = true;
                    vulnerableTime = 3f;
                 
                } else {
                    anim.Play("heavyAttack");
                    //myRigid.AddForce(Vector3.left * 300);
                    
                }

            }

            if (vulnerable == true){
                if (vulnerableTime >= 0 && rollTime > 0){
                    anim.Play("heavyDamaged");

                } 
                
                if (vulnerableTime < 0 && rollTime > 0){
                    anim.Play("heavyAttack");
                    //myRigid.AddForce(Vector3.left * 300);

                }

            }

        }

    }

}