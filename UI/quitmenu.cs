using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quitmenu : MonoBehaviour
{

   [SerializeField]
   GameObject QuitMenuPannel;

    // [SerializeField]
    // Button  YesButtin;


    // [SerializeField]
    //  Button  NoButton;
    // Start is called before the first frame update
    void Awake()
    {
        QuitMenuPannel.SetActive(false);
        // YesButtin.onClick.AddListener(OnYesClicked);
        // NoButton.onClick.AddListener(OnNoClicked);

    }
    public void OnYesClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNoClicked()
    {
      //  GameManager.Instance.playerIsPaused = false;
        QuitMenuPannel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (QuitMenuPannel.activeSelf)
            return;

       // if (GameManager.Instance.Inputcontroller.Escape)
      //  {
          //  gameObject.SetActive(true);

           // GameManager.Instance.playerIsPaused = true;
      //  }
    }
}

