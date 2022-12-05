using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {
    public GameObject prefab;
    public int health = 0;
    public int retries = 0;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public Animator anim;

    public static bool IsInputEnabled = true;

    void Start(){
        anim = prefab.GetComponent<Animator>();
        t1 = GameObject.Find("Updater").GetComponent<TextMeshProUGUI>();
        t2 = GameObject.Find("Retries").GetComponent<TextMeshProUGUI>();

    }

    public int getHealth(){
        return health;
        
    }
    
    public void setHealth(int s){
        health = s;
        
    }
    
    public void adjustHealth(int s){
        health += s;
        
        if (health <= 0){
            t1.text = "GAME OVER";
            anim.Play("trip");
            IsInputEnabled = false;

        } else {
            t1.text = "Health : " + health;

        }

    }

}