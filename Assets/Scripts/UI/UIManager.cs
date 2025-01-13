using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject FailPanel;
    [SerializeField] PlayerMovement playerController;
    
    [SerializeField] TMP_Text scoreCounter;
    [SerializeField] GameObject StartBtn;
    public static UIManager Instance;

    int Timer;



    public void StartGame()
    {
        StartBtn.SetActive(false);
        playerController.forwardSpeed = 6f;
        StartCoroutine(TimerRoutine());

    }


    IEnumerator TimerRoutine()
    {
        while (true)
        {
            Timer += 1;
            yield return new WaitForSeconds(1f);
            if (Timer > 60)
            {
                playerController.forwardSpeed = 8f;
            }else if (Timer > 120)
            {
                playerController.forwardSpeed = 10F;
            }
        }
    }
    private void Awake()
    {
        Instance = this;
        GameEvents.GameOver += GameOver;
    }

    void GameOver()
    {
        Invoke("SetFail", 3f);

    }

    void SetFail()
    {
        FailPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   public void Restart()
    {
        SceneManager.LoadScene(0);
        
    }

    public void UpdateScoreCounter()
    {
        scoreCounter.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
