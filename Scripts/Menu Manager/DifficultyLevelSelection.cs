using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyLevelSelection : MonoBehaviour
{
    public Button easyLevelButton, mediumLevelButton, hardLevelButton;
    public GameObject easyTick, mediumTick, hardTick;
    private void Start()
    {
        
        easyLevelButton.onClick.AddListener(onClickEasyMode);
        mediumLevelButton.onClick.AddListener(onClickMediumMode);
        hardLevelButton.onClick.AddListener(onClickHardMode);
    }
    private void Update()
    {
        if (CloudSaveManager.instance.difficultyLevel == 1)
        {
            easyTick.SetActive(true);
            mediumTick.SetActive(false);
            hardTick.SetActive(false);
        }
        else if (CloudSaveManager.instance.difficultyLevel == 2)
        {
            easyTick.SetActive(false);
            mediumTick.SetActive(true);
            hardTick.SetActive(false);
        }
        else if (CloudSaveManager.instance.difficultyLevel == 3)
        {
            easyTick.SetActive(false);
            mediumTick.SetActive(false);
            hardTick.SetActive(true);
        }
    }
    void onClickEasyMode()
    {
        AudioManager.instance.playTabSound();
        StaticData.DifficultyLevelData = 1;
        StaticData.SaveDifficultyLevelData = true;
    }
    void onClickMediumMode()
    {
        AudioManager.instance.playTabSound();
        StaticData.DifficultyLevelData = 2;
        StaticData.SaveDifficultyLevelData = true;
    }
    void onClickHardMode()
    {
        AudioManager.instance.playTabSound();
        StaticData.DifficultyLevelData = 3;
        StaticData.SaveDifficultyLevelData = true;
    }
}
