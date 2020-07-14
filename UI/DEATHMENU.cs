using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;
public class DEATHMENU : MonoBehaviour
{

    public Text HighScoreKillText;
    public Text HighScorePointText;

    public Text CurrentKillText;
    public Text CurrentScorePointText;



    public PlayerHealth2 playerhealth;

    [SerializeField]
    GameObject DeathMenuPannel;
    [SerializeField]
    GameObject EscapeMenuPannel;

   // public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        DeathMenuPannel.SetActive(false);
      //  playerhealth = GetComponent<PlayerHealth2>();
    }

    public void ToggleEndMenu()
    {
        DeathMenuPannel.SetActive(true);
    }


    public void Restart()
    {
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.playerIsPaused = false;
    }


    public void LoadLastCheckPoint()
    {
        playerhealth.spwanatnewspwanpoint();

        GameManager.Instance.playerIsPaused = false;
    }

    public void QuitToMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

        HighScoreKillText.text = "High kill : " + PlayerPrefs.GetFloat("Highkill");
        HighScorePointText.text = "High score : " + PlayerPrefs.GetFloat("HighscorePoint");

        // CurrentTimeText.text = "Current Time : " + PlayerPrefs.GetFloat("CurrentTime");
        CurrentKillText.text = "Current kill : " + PlayerPrefs.GetFloat("Currentkill");
        CurrentScorePointText.text = "Current score : " + PlayerPrefs.GetFloat("CurrentscorePoint");


        if (DeathMenuPannel.activeSelf)
        {

            EscapeMenuPannel.SetActive(false);
            GameManager.Instance.playerIsPaused = true;
            return;

        }
        //GameManager.Instance.playerIsPaused = true;
    }
}
