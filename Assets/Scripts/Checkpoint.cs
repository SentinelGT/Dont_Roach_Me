using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
   private GameMaster gm;
   private Renderer rend;
   private Light lit;
   //temporary variable
   //public int damage = 5;
   //end of tempory variable

   
   

   void Start(){
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       rend = GetComponent<Renderer>();
       lit = GetComponent<Light>();
       
   }

   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player")){
           gm.lastCheckPointPos = transform.position;
           rend.material.color = Color.green;
           lit.color = Color.green;
           //temporary code
           //PlayerHealth.instance.DamageplayerHealth(damage);
           
       }
       
   }
}

