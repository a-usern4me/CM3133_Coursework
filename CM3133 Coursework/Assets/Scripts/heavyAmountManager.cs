using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyAmountManager : MonoBehaviour {
    public int heavyNumber = 0;
    public static bool lowEnough = true;
    public static bool vulnerable = false;
 
    void Start(){
        
    }

    public int getAmount(){
        return heavyNumber;
        
    }
    
    public void setAmount(int s){
        heavyNumber = s;
        
    }
    
    public void adjustAmount(int s){
        heavyNumber += s;

        if (heavyNumber >= 1){
            lowEnough = false;

        } else {
            lowEnough = true;
        }
    
    }

}