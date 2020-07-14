using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShow2 : MonoBehaviour
{
  
   // public Text HighScoreKillText;
   // public Text HighScorePointText;
   public Text CurrentTimeText;
  //  public Text CurrentKillText;
  //  public Text CurrentScorePointText;


    public Text timerText;
    private float starttime;

    private bool isrunning=false;

    public Text Score;
    public static int scorevalue = 0;

    public Text Kill;
  public static int killvalue = 0;

    void Start()
    {
     
    }
    void starttimer()
    {

        

        if(!isrunning )
        {
            isrunning = false;
          //  starttime = Time.time;

            float t = Time.time - starttime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = "Time: " + minutes + ":" + seconds;
            CurrentTimeText.text = "Time: " + minutes + ":" + seconds;
        }
    }

    void stoptimer()
    {
        if (isrunning)
        {
            isrunning = true;
           // stoptime = Time.time;
        }
    }

    void scorecount()
    {
       
      //  HighScoreKillText.text = "High kill : " + PlayerPrefs.GetFloat("Highkill");
     //   HighScorePointText.text = "High score : " + PlayerPrefs.GetFloat("HighscorePoint");

         // CurrentTimeText.text = "Current Time : " + PlayerPrefs.GetFloat("CurrentTime");
      //  CurrentKillText.text = "Current kill : " + PlayerPrefs.GetFloat("Currentkill");
     //   CurrentScorePointText.text = "Current score : " + PlayerPrefs.GetFloat("CurrentscorePoint");

        if (PlayerPrefs.GetFloat("HighscorePoint") < scorevalue)
            PlayerPrefs.SetFloat("HighscorePoint", scorevalue);

        if (PlayerPrefs.GetFloat("Highkill") < killvalue)
            PlayerPrefs.SetFloat("Highkill", killvalue);

        PlayerPrefs.SetFloat("Currentkill", killvalue);
        PlayerPrefs.SetFloat("CurrentscorePoint", scorevalue);
    }
    void Update()
    {
        scorecount();

        if( GameManager.Instance.playerIsPaused == true)
        {
            isrunning = true; 
          stoptimer();
       }
        if (GameManager.Instance.playerIsPaused == false)
        {
            isrunning = false;
            starttimer(); 
        }  
        starttimer();
        

        Kill.text = "Kill: " + killvalue;
        Score.text = "Score: " + scorevalue;
    }
}
