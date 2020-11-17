using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CountDownTimer : MonoBehaviour
{

    //used to respawn the player on timer ends
    private string Respawn = "Level1";
    [SerializeField] float startTime = 300f;

    [SerializeField] TextMeshProUGUI timerText;

    //member vairable to access elsewhere
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        // coroutines but be called regardless unless specified 
        StartCoroutine(GameTimer());
    }

    void Update() 
    {
        //TimeOut();
    }

    // should be public because some game elements need the time
    // using coroutines
    public IEnumerator GameTimer()
    {
        timer = startTime;

        do{
            //Executes at least once
            timer -= Time.deltaTime;

            FormatText();
            //waits just a single frame
            yield return null;
        } while (timer > 0);
    }

    private void FormatText()
    {
        int days = (int)(timer / 86400) % 365;
        int hours = (int)(timer / 3600) % 24;
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);


        // initilize text per frame, clears out space
        timerText.text = "";

        // adds days to timer but ignores otherwise
        if (days > 0) { timerText.text += days + "d: "; } // 7d
        if (hours > 0) { timerText.text += hours + ":"; }
        if (minutes > 0) { timerText.text += minutes + ":";}
        if (seconds > 0) { timerText.text += seconds; }

        TimeOut(timer);
    }

    //restart level on time out
    private void TimeOut(float time) {
        if (time <= 0)
        {
            SceneManager.LoadScene(Respawn);
        } else {
            //Debug.Log("timer: " + time);
        }

    }

}
