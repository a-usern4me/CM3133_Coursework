using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public GameObject rootCanvas;
    public GameObject playerStatus;
    public Rigidbody2D PlayerRigid;
    public Rigidbody2D heavyEnemyRigid;
    public Rigidbody2D wall;
    public TextMeshProUGUI buttonID;
    private TextMeshProUGUI b2;
    public AudioSource music;

    void Start(){
        b2 = GameObject.Find("Level2").GetComponent<TextMeshProUGUI>();
        
    }

    void Update(){

    }

    public void handleClick(){
        if (buttonID == b2){
            SceneManager.LoadScene("Stage 2");
            DontDestroyOnLoad(PlayerRigid);
            DontDestroyOnLoad(rootCanvas);
            DontDestroyOnLoad(playerStatus);
            DontDestroyOnLoad(heavyEnemyRigid);
            DontDestroyOnLoad(wall);

        }
    
    }

}