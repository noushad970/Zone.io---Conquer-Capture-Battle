using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownBarButtonManagement : MonoBehaviour
{
    public Button ItemStoreButton, CharStoreButton, PlayMenuButton, PowerUpMenuButton, ExitGameButton;
    public GameObject ItemStore, CharStore, PlayMenu, PowerUpMenu, ExitGame;

    private void Start()
    {
        ItemStore.SetActive(false);
        CharStore.SetActive(false);
        PlayMenu.SetActive(true);
        if(PowerUpMenu != null)
        PowerUpMenu.SetActive(false);
        ExitGame.SetActive(false);
        ItemStoreButton.onClick.AddListener(OnclickItem);
        CharStoreButton.onClick.AddListener(OnclickChar);
        PlayMenuButton.onClick.AddListener(OnclickPlay);
        PowerUpMenuButton.onClick.AddListener(OnclickPower);
        ExitGameButton.onClick.AddListener(OnclickExit);
    }
    void OnclickItem()
    {
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
    }
    void OnclickChar()
    {
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
    }
    void OnclickPlay()
    {
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
    }
    void OnclickPower()
    {
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
    }
    void OnclickExit()
    {
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
    }
}
