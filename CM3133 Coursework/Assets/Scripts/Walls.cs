using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {
    public Rigidbody2D myRigid;

    void Start(){
        myRigid = this.GetComponent<Rigidbody2D>();

    }

    void Update(){

    }

    private void OnCollisionEnter2D(Collision2D collision){
        print("Contact with wall");
    } 

}