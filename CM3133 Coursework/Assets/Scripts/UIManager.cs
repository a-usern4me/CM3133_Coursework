using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameStateManager gsm;
  
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;

    private int health;
    private int retries;

    void Start(){
       health = gsm.health;
       retries = gsm.retries;

    }

    void Update(){

    }

    public void handleClick(){
        GameStateManager.IsInputEnabled = true;
        gsm.adjustHealth(3);
        retries += 1;
        t1.text = "Health : " + health;
        t2.text = "Retries : " + retries;

    }

}