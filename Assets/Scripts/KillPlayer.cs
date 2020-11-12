using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject thePlayer;
    private GameMaster gm;
    
    
    void Start()
    {
     gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            thePlayer.transform.position = gm.lastCheckPointPos;
            //SceneManager.LoadScene(Respawn);
        }
    }
}
