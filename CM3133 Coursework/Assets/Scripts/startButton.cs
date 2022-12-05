using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class startButton : MonoBehaviour {
    public TextMeshProUGUI buttonID;
    private TextMeshProUGUI b1;

    /**

    private TextMeshProUGUI easy;
    private TextMeshProUGUI normal;
    private TextMeshProUGUI hard;
    public GameStateManager gsm;

    **/
  
    void Start(){
        b1 = GameObject.Find("Level1").GetComponent<TextMeshProUGUI>();

        /**

        easy = GameObject.Find("Easy").GetComponent<TextMeshProUGUI>();
        normal = GameObject.Find("Normal").GetComponent<TextMeshProUGUI>();
        hard = GameObject.Find("Hard").GetComponent<TextMeshProUGUI>();

        **/
    
    }

    void Update(){

    }

    public void handleClick(){
        if (buttonID == b1){
            SceneManager.LoadScene(1);

        }

        /**

        if (buttonID == easy){
            gsm.setHealth(5);
            SceneManager.LoadScene(1);
            
        }

        if (buttonID == normal){
            gsm.setHealth(3);
            SceneManager.LoadScene(1);

        }

        if (buttonID == hard){
            gsm.setHealth(1);
            SceneManager.LoadScene(1);
            
        }

        **/

    }

}