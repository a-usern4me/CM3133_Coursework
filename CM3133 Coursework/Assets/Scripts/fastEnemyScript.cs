using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastEnemyScript : MonoBehaviour {
    private float rolling = 0f;
    private Rigidbody2D fastRigid;
    Animator anim;

    void Start(){
        fastRigid = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        fastRigid.AddForce(Vector3.left * 350);
      
    }

    void Update(){
        rolling =- Time.deltaTime;

        if (Input.GetKey("d") && rolling < 0){
            rolling = 1f;

        }
     
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            if (rolling > 0){
                anim.Play("bossDefeated");
                Destroy(this.gameObject, 1f);
                
            } else {
                anim.Play("bossAttack");
                fastRigid.AddForce(Vector3.left * 400);

            }

        }

    }

}