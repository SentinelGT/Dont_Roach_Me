using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodstuffPickUp : MonoBehaviour
{
    public int worth = 1;
    

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            Destroy(gameObject);
            GameMaster.instance.IncreaseFoodstuffs(worth);
        }
 
    }
}