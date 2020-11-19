using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   public Transform teleportTarget;
   public GameObject thePlayer;
   private Renderer rend;

   void Start(){
       rend = GetComponent<Renderer>();
       
   }

   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player"))
        {
            thePlayer.transform.position = teleportTarget.transform.position;
            //rend.material.color = Color.green;
        }
           
       
   }
}
