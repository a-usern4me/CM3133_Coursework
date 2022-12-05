using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class Trigger : MonoBehaviour {
    public Rigidbody2D myRigid;
    public Rigidbody2D PlayerRigid;
    public Rigidbody2D heavyEnemyRigid;
    Animator anim;

    private bool nextStage;
    public GameObject playerStatus;
    public GameObject rootCanvas;
    private Vector3 heroStart;
    public Rigidbody2D wall;
   
    void Start(){
        myRigid = this.GetComponent<Rigidbody2D>();
        PlayerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Animator>();

        heroStart = PlayerRigid.transform.position;
        nextStage = false;

    }

    void Update(){
       
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            SceneManager.LoadScene("Stage 2");
            DontDestroyOnLoad(myRigid);
            DontDestroyOnLoad(PlayerRigid);
            DontDestroyOnLoad(heavyEnemyRigid);
            DontDestroyOnLoad(playerStatus);
            DontDestroyOnLoad(rootCanvas);
            DontDestroyOnLoad(wall);
        
            nextStage = true;
             
        }

    }

    void OnTriggerExit2D(Collider2D collider){
        if (nextStage == true){
            PlayerRigid.transform.position = heroStart;
            PlayerRigid.velocity = Vector3.zero;
            anim.SetBool("Victory", false);
            GameStateManager.IsInputEnabled = true;

        }
 
    }

}