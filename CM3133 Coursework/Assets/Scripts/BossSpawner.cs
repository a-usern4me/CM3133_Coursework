using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    public Rigidbody2D heavyEnemy;
    public GameObject tryThis;
    private GameObject round2;
    private Collider2D round2Box;
    private Vector3 startPos;
    public heavyAmountManager heavyStateManager;

    void Start(){
        heavyEnemy = GameObject.Find("heavyEnemy").GetComponent<Rigidbody2D>();
        round2Box = GameObject.Find("heavyEnemy").GetComponent<Collider2D>();
        startPos = heavyEnemy.transform.position;
       
    }

    void Update(){
        if (heavyAmountManager.lowEnough == true){
            if(Input.GetKey("p")){
                round2 = Instantiate(tryThis, startPos, Quaternion.identity);
                
                round2.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                
                round2Box.enabled = false;
                round2Box.enabled = true;

                heavyStateManager.adjustAmount(1);
                heavyAmountManager.vulnerable = false;

            }

        } else {
           print("Nope");
           
        }

    }

}