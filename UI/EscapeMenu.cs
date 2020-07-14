using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;
public class EscapeMenu : MonoBehaviour
{

    public Text HighScoreKillText;
    public Text HighScorePointText;

    public Text CurrentKillText;
    public Text CurrentScorePointText;



    [SerializeField]
    GameObject EscapeMenuPannel;

    [SerializeField]
    GameObject QuitMenuPannel;

    public PlayerHealth2 playerhealth;

    void Awake()
    {
        EscapeMenuPannel.SetActive(false);
        QuitMenuPannel.SetActive(false);
    }

    public void Resume()
    {
        
        EscapeMenuPannel.SetActive(false);

        GameManager.Instance.playerIsPaused = false;
    }


    public void Restart()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // EscapeMenuPannel.SetActive(false);
        GameManager.Instance.playerIsPaused = false;
    }


    public void LoadLastCheckPoint()
    {
        playerhealth.spwanatnewspwanpoint();

        EscapeMenuPannel.SetActive(false);
        GameManager.Instance.playerIsPaused = false;
    }

    public void QuitToMenu()
    {
        QuitMenuPannel.SetActive(true );

        //SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {

        HighScoreKillText.text = "High kill : " + PlayerPrefs.GetFloat("Highkill");
        HighScorePointText.text = "High score : " + PlayerPrefs.GetFloat("HighscorePoint");
        CurrentKillText.text = "Current kill : " + PlayerPrefs.GetFloat("Currentkill");
        CurrentScorePointText.text = "Current score : " + PlayerPrefs.GetFloat("CurrentscorePoint");



        if (EscapeMenuPannel.activeSelf)
            return;

        if (GameManager.Instance.Inputcontroller.Escape)
        {
            EscapeMenuPannel.SetActive(true);
            QuitMenuPannel.SetActive(false);
            GameManager.Instance.playerIsPaused = true;
        }
    }

}