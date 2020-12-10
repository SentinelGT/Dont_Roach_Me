using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
          
    [Header("Health")]
   public int playerHealth = 3;

void Awake(){

       if(instance == null){
           instance = this;
           DontDestroyOnLoad(instance);
       }else{
           Destroy(gameObject);
       }
   }

public void DamageplayerHealth(int damage) {
    playerHealth -= damage;
    if (playerHealth <= 0){
        playerHealth = 100;
        
    if (damage > 1000){
        playerHealth = 100;
    }
    }

}


}
