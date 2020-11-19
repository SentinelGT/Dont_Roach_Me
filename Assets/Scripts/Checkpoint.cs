using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
   private GameMaster gm;
   private Renderer rend;
   
   

   void Start(){
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       rend = GetComponent<Renderer>();
       
   }

   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player")){
           gm.lastCheckPointPos = transform.position;
           rend.material.color = Color.green;
           
       }
       
   }
}
