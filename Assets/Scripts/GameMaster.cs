using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public static GameMaster instance;
   public Vector2 lastCheckPointPos;

   [Header("Foodstuffs")]
   public int foodstuffs = 0;

   void Awake(){

       if(instance == null){
           instance = this;
           DontDestroyOnLoad(instance);
       }else{
           Destroy(gameObject);
       }
   }

public void IncreaseFoodstuffs(int amount) {
    foodstuffs += amount;
}

}
