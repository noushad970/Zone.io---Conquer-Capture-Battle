using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownBarButtonManagement : MonoBehaviour
{
    public static DownBarButtonManagement Instance;
    public Button ItemStoreButton, CharStoreButton, PlayMenuButton, PowerUpMenuButton, ExitGameButton;
    public GameObject ItemStore, CharStore, PlayMenu, PowerUpMenu, ExitGame;
    public Button yesExitButton, NoExitButton;
    public Button GemAmountButton, CoinAmountButton;
    public GameObject characterPlaceObject;
    private void Update()
    {
        Debug.Log("Total Coin: " + CloudSaveManager.instance.totalCoin);
        if (OpenBoxAndGetGift.isClosedMysteryBox)
        {
            OpenBoxAndGetGift.isClosedMysteryBox = false;
            OnclickPlay(); 
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        ItemStore.SetActive(false);
        CharStore.SetActive(false);
        PlayMenu.SetActive(true);
        if(PowerUpMenu != null)
        PowerUpMenu.SetActive(false);
        ExitGame.SetActive(false);
        ItemStoreButton.onClick.AddListener(OnclickItem);
        GemAmountButton.onClick.AddListener(OnclickItem);
        CoinAmountButton.onClick.AddListener(OnclickItem);
        CharStoreButton.onClick.AddListener(OnclickChar);
        PlayMenuButton.onClick.AddListener(OnclickPlay);
        PowerUpMenuButton.onClick.AddListener(OnclickPower);
        ExitGameButton.onClick.AddListener(OnclickExit);
        yesExitButton.onClick.AddListener(exitGame);
        NoExitButton.onClick.AddListener(DisableExitConfirmationPanel);
        characterPlaceObject.SetActive(true);
    }
    
    void OnclickItem()
    {
        AudioManager.instance.playSwapSound();
        ItemStoreButton.enabled = false;
        CharStoreButton.enabled = true;
        PlayMenuButton.enabled = true;
        ExitGameButton.enabled = true;
        PowerUpMenuButton.enabled = true;
        ItemStore.SetActive(true);
        CharStore.SetActive(false);
        PlayMenu.SetActive(false);

        if (PowerUpMenu != null)
            PowerUpMenu.SetActive(false);
        ExitGame.SetActive(false);
        characterPlaceObject.SetActive(false);
    }
    void OnclickChar()
    {
        AudioManager.instance.playSwapSound();
        ItemStoreButton.enabled = true;
        CharStoreButton.enabled = false;
        PlayMenuButton.enabled = true;
        ExitGameButton.enabled = true;
        PowerUpMenuButton.enabled = true;
        ItemStore.SetActive(false);
        CharStore.SetActive(true);
        PlayMenu.SetActive(false);
        if (PowerUpMenu != null)
            PowerUpMenu.SetActive(false);
        ExitGame.SetActive(false);
        characterPlaceObject.SetActive(true);
    }
    public void OnclickPlay()
    {
        AudioManager.instance.playSwapSound();
        ItemStoreButton.enabled = true;
        CharStoreButton.enabled = true;
        PlayMenuButton.enabled = false;
        ExitGameButton.enabled = true;
        PowerUpMenuButton.enabled = true;
        ItemStore.SetActive(false);
        CharStore.SetActive(false);
        PlayMenu.SetActive(true);
        if (PowerUpMenu != null)
            PowerUpMenu.SetActive(false);
        ExitGame.SetActive(false);
        characterPlaceObject.SetActive(true);
    }
    void OnclickPower()
    {
        AudioManager.instance.playSwapSound();
        ItemStoreButton.enabled = true;
        CharStoreButton.enabled = true;
        PlayMenuButton.enabled = true;
        ExitGameButton.enabled = true;
        PowerUpMenuButton.enabled = false;
        ItemStore.SetActive(false);
        CharStore.SetActive(false);
        PlayMenu.SetActive(false);
        if (PowerUpMenu != null)
            PowerUpMenu.SetActive(true);
        ExitGame.SetActive(false);
        characterPlaceObject.SetActive(false);
    }
    void OnclickExit()
    {
        AudioManager.instance.playSwapSound();
        ItemStoreButton.enabled = true;
        CharStoreButton.enabled = true;
        PlayMenuButton.enabled = true;
        ExitGameButton.enabled = false;
        PowerUpMenuButton.enabled = true;
        ItemStore.SetActive(false);
        CharStore.SetActive(false);
        PlayMenu.SetActive(false);
        if (PowerUpMenu != null)
            PowerUpMenu.SetActive(false);
        ExitGame.SetActive(true);
        characterPlaceObject.SetActive(false);
    }
    void exitGame()
    {
        #if UNITY_EDITOR
        // This will stop the play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;
        
#else
        // This will quit the application in a build
        Application.Quit();
        
#endif
    }
    void DisableExitConfirmationPanel()
    {
        AudioManager.instance.playTabSound();
        ExitGame.SetActive(false);
        OnclickPlay();
    }
}
