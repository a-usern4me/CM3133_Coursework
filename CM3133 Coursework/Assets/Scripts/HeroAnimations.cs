using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour {
    private float guardTime = 0f;
    private float rollTime = 0f;

    Animator anim;
    public Rigidbody2D myRigid;
    private GameStateManager gsm;

    void Start() {        
        anim = this.GetComponent<Animator>();
        myRigid = this.GetComponent<Rigidbody2D>();
        gsm = GameObject.Find("Player").GetComponent<GameStateManager>();

    }

    void Update() {
        guardTime -= Time.deltaTime;
        rollTime -= Time.deltaTime;

        if (GameStateManager.IsInputEnabled){
            //Blocking Animation
            if (Input.GetKey("a") && guardTime <= 0f){
                anim.Play("blockAnimation");
                guardTime = 1.0f;
                rollTime = 1f;


            } else {
                anim.SetBool("Blocking", false);

            }

            //Rolling Animation
            if (Input.GetKey("d") && rollTime <= 0f){
                anim.Play("combatRoll");
                this.transform.Translate(1.5f,0f,0f);
                myRigid.velocity = Vector3.zero;
                rollTime = 0.45f;

            } else {        
                anim.SetBool("Rolling", false);  

            }

        }               
              
    }

}