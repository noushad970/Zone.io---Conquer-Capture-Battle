using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public Button[] commonChar, rearChar, EpicChar, SpecialChar;
    public GameObject[] commonCharObject, rearCharObject, EpicCharObject, SpecialCharObject;
    // Start is called before the first frame update
    void Start()
    {
        commonChar[0].onClick.AddListener(onClickCommon0Button);
        commonChar[1].onClick.AddListener(onClickCommon1Button);
        commonChar[2].onClick.AddListener(onClickCommon2Button);
        commonChar[3].onClick.AddListener(onClickCommon3Button);
        commonChar[4].onClick.AddListener(onClickCommon4Button);
        commonChar[5].onClick.AddListener(onClickCommon5Button);
        commonChar[6].onClick.AddListener(onClickCommon6Button);
        commonChar[7].onClick.AddListener(onClickCommon7Button);
        commonChar[8].onClick.AddListener(onClickCommon8Button);

        rearChar[0].onClick.AddListener(onClickRear0Button);
        rearChar[1].onClick.AddListener(onClickRear1Button);
        rearChar[2].onClick.AddListener(onClickRear2Button);
        rearChar[3].onClick.AddListener(onClickRear3Button);
        rearChar[4].onClick.AddListener(onClickRear4Button);
        rearChar[5].onClick.AddListener(onClickRear5Button);
        rearChar[6].onClick.AddListener(onClickRear6Button);
        rearChar[7].onClick.AddListener(onClickRear7Button);
        rearChar[8].onClick.AddListener(onClickRear8Button);

        EpicChar[0].onClick.AddListener(onClickEpic0Button);
        EpicChar[1].onClick.AddListener(onClickEpic1Button);
        EpicChar[2].onClick.AddListener(onClickEpic2Button);
        EpicChar[3].onClick.AddListener(onClickEpic3Button);
        EpicChar[4].onClick.AddListener(onClickEpic4Button);
        EpicChar[5].onClick.AddListener(onClickEpic5Button);
        EpicChar[6].onClick.AddListener(onClickEpic6Button);

        SpecialChar[0].onClick.AddListener(onClickSpecial0Button);
        SpecialChar[1].onClick.AddListener(onClickSpecial1Button);
        SpecialChar[2].onClick.AddListener(onClickSpecial2Button);
        SpecialChar[3].onClick.AddListener(onClickSpecial3Button);
        SpecialChar[4].onClick.AddListener(onClickSpecial4Button);
        SpecialChar[5].onClick.AddListener(onClickSpecial5Button);
        
    }
    private void Awake()
    {
        InstertitialAds.instance.ShowAd();
    }

    private void Update()
    {
        if (CloudSaveManager.readyToShowCharacterInMenu)
        {
            CloudSaveManager.readyToShowCharacterInMenu = false;
            SelectedCharShow();
        }
    }
    void onClickCommon0Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 100;
        StaticData.SaveCharacterValue = true;
        setAllCharacterActiveFalse();
        commonCharObject[0].SetActive(true);
    }
    void onClickCommon1Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 101;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon2Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 102;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon3Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 103;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon4Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 104;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon5Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 105;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon6Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 106;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon7Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 107;
        StaticData.SaveCharacterValue = true;
    }
    void onClickCommon8Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 108;
        StaticData.SaveCharacterValue = true;
    }
    //for rear characters
    void onClickRear0Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 200;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear1Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 201;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear2Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 202;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear3Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 203;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear4Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 204;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear5Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 205;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear6Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 206;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear7Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 207;
        StaticData.SaveCharacterValue = true;
    }
    void onClickRear8Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 208;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic0Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 300;
        StaticData.SaveCharacterValue = true;

    }
    void onClickEpic1Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 301;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic2Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 302;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic3Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 303;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic4Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 304;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic5Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 305;
        StaticData.SaveCharacterValue = true;
    }
    void onClickEpic6Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 306;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial0Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 400;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial1Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 401;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial2Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 402;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial3Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 403;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial4Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 404;
        StaticData.SaveCharacterValue = true;
    }
    void onClickSpecial5Button()
    {
        AudioManager.instance.playTabSound();
        StaticData.CharacterValue = 405;
        StaticData.SaveCharacterValue = true;
    }

    void setAllCharacterActiveFalse()
    {
        for(int i=0;i<commonCharObject.Length;i++)
        {
            commonCharObject[i].SetActive(false);
        }
        for (int i = 0; i < SpecialCharObject.Length; i++)
        {
            SpecialCharObject[i].SetActive(false);
        }
        for (int i = 0; i < EpicCharObject.Length; i++)
        {
            EpicCharObject[i].SetActive(false);
        }
        for (int i = 0; i < rearCharObject.Length; i++)
        {
            rearCharObject[i].SetActive(false);
        }
    }
    void SelectedCharShow()
    {
        if (CloudSaveManager.instance.selectedCharValue == 100)
        {
            setAllCharacterActiveFalse();
            commonCharObject[0].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 101)
        {
            setAllCharacterActiveFalse();
            commonCharObject[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 102)
        {
            setAllCharacterActiveFalse();
            commonCharObject[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 103)
        {
            setAllCharacterActiveFalse();
            commonCharObject[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 104)
        {
            setAllCharacterActiveFalse();
            commonCharObject[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 105)
        {
            setAllCharacterActiveFalse();
            commonCharObject[5].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 106)
        {
            setAllCharacterActiveFalse();
            commonCharObject[6].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 107)
        {
            setAllCharacterActiveFalse();
            commonCharObject[7].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 108)
        {
            setAllCharacterActiveFalse();
            commonCharObject[8].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 200)
        {
            setAllCharacterActiveFalse();
            rearCharObject[0].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 201)
        {
            setAllCharacterActiveFalse();
            rearCharObject[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 202)
        {
            setAllCharacterActiveFalse();
            rearCharObject[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 203)
        {
            setAllCharacterActiveFalse();
            rearCharObject[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 204)
        {
            setAllCharacterActiveFalse();
            rearCharObject[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 205)
        {
            setAllCharacterActiveFalse();
            rearCharObject[5].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 206)
        {
            setAllCharacterActiveFalse();
            rearCharObject[6].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 207)
        {
            setAllCharacterActiveFalse();
            rearCharObject[7].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 208)
        {
            setAllCharacterActiveFalse();
            rearCharObject[8].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 300)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[0].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 301)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 302)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 303)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 304)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 305)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[5].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 306)
        {
            setAllCharacterActiveFalse();
            EpicCharObject[6].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 400)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[0].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 401)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 402)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 403)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 404)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.selectedCharValue == 405)
        {
            setAllCharacterActiveFalse();
            SpecialCharObject[5].SetActive(true);
        }
        


    }
}
