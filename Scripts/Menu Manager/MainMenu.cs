using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	
	public Button pauseButton, GotoMainMenuButtons, GotoMainMenuBtn, ResumeButton,restartGame;
	public TMP_Text totalCoin, Totalkill;

    public GameObject gameOver;
    public GameObject pauseMenus;
    public GameObject score, kill, pause, Map;
    int coin;
    private void Start()
    {
		restartGame.onClick.AddListener(Retry);
		pauseButton.onClick.AddListener(pauseGame);
		ResumeButton.onClick.AddListener(resumeGame);
		GotoMainMenuButtons.onClick.AddListener(GameManager.gm.gotoMainMenu);
        GotoMainMenuBtn.onClick.AddListener(gotoMainMenus);

        //UnityAdsManager.Instance.ShowInterstitialAd();
        coin = CloudSaveManager.instance.totalCoin;
        Debug.Log("Total coin in GamePlay:" + coin);
       
        GameManager.gm.mm = this;
        //DontDestroyOnLoad(this);
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            gameOver.SetActive(false);
            pauseMenus.SetActive(false);
            score.SetActive(true);
            kill.SetActive(true);
            pause.SetActive(true);
            Map.SetActive(true);
        }
    }
    
    private void Update()
    {
		float x = ((EnemySpawnerAI.totalPlayerEliminateByPlayer * 10) + (SceneTimeCounter.TotalTime / 4) + coin);
		float y = EnemySpawnerAI.totalPlayerEliminateByPlayer;
        totalCoin.text = x.ToString();
		Totalkill.text = y.ToString();
		Debug.Log("X:" + x + "Y:" + y);
        if (SceneManager.GetActiveScene().name != "Gameplay")
        {
            gameOver.SetActive(false);
            pauseMenus.SetActive(false);
            score.SetActive(false);
            kill.SetActive(false);
            pause.SetActive(false);
            Map.SetActive(false);
        }
    }
  

	public void Retry()
	{
       
        GameManager.gm.RestartScene();
        pauseMenus.SetActive(false);
        gameOver.SetActive(false);

    }

	public void GameOver()
	{

        gameOver.SetActive(true);
        pauseMenus.SetActive(false);
        StaticData.SaveTotalplayMatchCount = true;
    }
	void gotoMainMenus()
    {
        GameManager.gm.gotoMainMenu();
        score.SetActive(false);
        kill.SetActive(false);
        pause.SetActive(false);
        Map.SetActive(false);
        pauseMenus.SetActive(false);
        gameOver.SetActive(false);

    }
	void resumeGame()
    {
        AudioManager.instance.playTabSound();
        pauseMenus.SetActive(false);
        gameOver.SetActive(false);
        GameManager.gm.resumeMenu();
		
	}
	void pauseGame()
    {
        AudioManager.instance.playTabSound();
        pauseMenus.SetActive(true);
        gameOver.SetActive(false);

        GameManager.gm.pauseMenu();
	}
}