using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class muteButton : MonoBehaviour {
    public TextMeshProUGUI m1;
    public AudioSource music;
    private float sound;
    private float pass;

    void Start(){
        

    }

    void Update(){
        music.volume = PlayerPrefs.GetFloat("Volume");
        sound = music.volume;

    }

    public void handleClick(){
        if (sound > 0){
            music.volume = 0;
            pass = 0;

        } else {
            music.volume = 0.506f;
            pass = 0.506f;

        }

        PlayerPrefs.SetFloat("Volume", pass);
        PlayerPrefs.Save();

    }

}