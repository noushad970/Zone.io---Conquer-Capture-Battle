using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopMenu : MonoBehaviour
{
    public Button commonCharButton,RearCharButton,EpicCharButton,SpecialCharButton;
    public GameObject commonBG, EpicBg, SpecialBG, RearBG;
    private void Start()
    {
        commonCharButton.onClick.AddListener(onclickCommon);
        RearCharButton.onClick.AddListener(onclickRear);
        EpicCharButton.onClick.AddListener(onclickEpic);
        SpecialCharButton.onClick.AddListener(onclickSpecial);
    }
    void onclickCommon()
    {
        AudioManager.instance.playSwapSound();
        commonBG.SetActive(true);
        EpicBg.SetActive(false);
        SpecialBG.SetActive(false);
        RearBG.SetActive(false);
        commonCharButton.enabled = false;
        RearCharButton.enabled = true;
        EpicCharButton.enabled = true;
        SpecialCharButton.enabled = true;
    }
    void onclickEpic()
    {
        AudioManager.instance.playSwapSound();
        commonBG.SetActive(false);
        EpicBg.SetActive(true);
        SpecialBG.SetActive(false);
        RearBG.SetActive(false);
        commonCharButton.enabled = true;
        RearCharButton.enabled = true;
        EpicCharButton.enabled = false;
        SpecialCharButton.enabled = true;
    }
    void onclickRear()
    {
        AudioManager.instance.playSwapSound();
        commonBG.SetActive(false);
        EpicBg.SetActive(false);
        SpecialBG.SetActive(false);
        RearBG.SetActive(true);
        commonCharButton.enabled = true;
        RearCharButton.enabled = false;
        EpicCharButton.enabled = true;
        SpecialCharButton.enabled = true;
    }
    void onclickSpecial()
    {
        AudioManager.instance.playSwapSound();
        commonBG.SetActive(false);
        EpicBg.SetActive(false);
        SpecialBG.SetActive(true);
        RearBG.SetActive(false);
        commonCharButton.enabled = true;
        RearCharButton.enabled = true;
        EpicCharButton.enabled = true;
        SpecialCharButton.enabled = false;
    }

}
