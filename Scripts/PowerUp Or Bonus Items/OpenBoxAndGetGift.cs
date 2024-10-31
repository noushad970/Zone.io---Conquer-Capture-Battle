using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoxAndGetGift : MonoBehaviour
{
    public GameObject giftBox;
    public GameObject rewardParent;
    public GameObject[] rewardChar;
    public GameObject RewardGem, rewardCoin100, rewardCoin200, rewardCoin300, rewardCoin500, rewardCoin1000, rewardCoin10000;
    public GameObject charBarForBoxOpen,charBarForMenuCharacter;
    bool isOpeningCreate;
    int randomNum;
    int randomGiftNumber;
    public GameObject[] mainGamePanels;
    public static bool isClosedMysteryBox;
    public Button openMysteryBoxButton;
    public GameObject charBar;
    // Start is called before the first frame update
    void Start()
    {
        charBarForBoxOpen.SetActive(false);
        isClosedMysteryBox = false;
        isOpeningCreate = false;
        setActiveCharfalse();
        openMysteryBoxButton.onClick.AddListener(OpenBox);
    }
    private void Update()
    {
        if (isOpeningCreate)
        {
            giftBox.SetActive(true);
        }
        else
        {
            giftBox.SetActive(false);
        }

        Debug.Log("CloudSaveManager.instance.specialCarVal: " + CloudSaveManager.instance.specialCarVal);
    }
    void OpenBox()
    {
        StartCoroutine(openCreate());
    }
    //25 for character, 49 for 10k coins, 40-45 for 1 gem
    IEnumerator openCreate()
    {
        charBarForBoxOpen.SetActive(true);

        charBarForMenuCharacter.SetActive(false);
        for(int i=0; i < mainGamePanels.Length; i++)
        {
            mainGamePanels[i].SetActive(false);
        }
        setActiveCharfalse();
        isOpeningCreate =true;
        yield return new WaitForSeconds(4.2f);
        isOpeningCreate = false;
        randomGiftNumber = Random.Range(0, 50);
        if(randomGiftNumber>=0 && randomGiftNumber < 5)
        {
            //1000 coin given
            StaticData.coinData = 1000;
            StaticData.SaveCoinData = true;
            rewardCoin1000.SetActive(true);
        }
        else if (randomGiftNumber >= 5 && randomGiftNumber < 10)
        {
            //500 coin given
            StaticData.coinData = 500;
            StaticData.SaveCoinData = true;
            rewardCoin500.SetActive(true);
        }
        else if (randomGiftNumber >= 10 && randomGiftNumber < 20)
        {
            //200 coin given
            StaticData.coinData = 200;
            StaticData.SaveCoinData = true;
            rewardCoin200.SetActive(true);
        }
        else if (randomGiftNumber >= 20 && randomGiftNumber <= 24)
        {
            //300 coin given
            StaticData.coinData = 300;
            StaticData.SaveCoinData = true;
            rewardCoin300.SetActive(true);
        }
        else if (randomGiftNumber >= 26 && randomGiftNumber < 35)
        {
            //100 coin
            StaticData.coinData = 100;
            StaticData.SaveCoinData = true;
            rewardCoin100.SetActive(true);
        }//in below the character get from box code is given
        else if (randomGiftNumber == 25)
        {
            if (CloudSaveManager.instance.specialCarVal == 0)
            {
                rewardChar[0].SetActive(true);
                StaticData.SaveSpecialCharData = true;  
            }
            else if (CloudSaveManager.instance.specialCarVal == 1)
            {
                rewardChar[1].SetActive(true);
                StaticData.SaveSpecialCharData = true;
            }
            else if (CloudSaveManager.instance.specialCarVal == 2)
            {
                rewardChar[2].SetActive(true);
                StaticData.SaveSpecialCharData = true;
            }
            else if (CloudSaveManager.instance.specialCarVal == 3)
            {
                rewardChar[3].SetActive(true);
                StaticData.SaveSpecialCharData = true;
            }
            else if (CloudSaveManager.instance.specialCarVal == 4)
            {
                rewardChar[4].SetActive(true);
                StaticData.SaveSpecialCharData = true;
            }
            else if (CloudSaveManager.instance.specialCarVal == 5)
            {
                rewardChar[5].SetActive(true);
                StaticData.SaveSpecialCharData = true;
            }
            else if (CloudSaveManager.instance.specialCarVal == 6)
            {

                RewardGem.SetActive(true);
                StaticData.gemData = 5;
                StaticData.SaveGemData = true;
                //disable get special character from mysterybox
            }
            
            //character given
        }
        else if (randomGiftNumber == 49)
        {
            StaticData.coinData = 10000;
            StaticData.SaveCoinData = true;
            rewardCoin10000.SetActive(true);
            //10k coin given
        }
        else if(randomGiftNumber>=40 && randomGiftNumber < 44)
        {
            RewardGem.SetActive(true);
            StaticData.gemData = 5;
            StaticData.SaveGemData = true;
            //5 gem given
        }
        else
        {
            StaticData.coinData = 100;
            StaticData.SaveCoinData = true;
            rewardCoin100.SetActive(true);
            //100 coin given
        }
        yield return new WaitForSeconds(4f);
        setActiveCharfalse();
        isClosedMysteryBox = true;
        charBarForBoxOpen.SetActive(false);
        charBarForMenuCharacter.SetActive(true);


    }
    void setActiveCharfalse()
    {
        for(int i=0;i<rewardChar.Length;i++)
        {
            rewardChar[i].SetActive(false);
        }
        rewardCoin100.SetActive(false);
        rewardCoin200.SetActive(false);
        rewardCoin300.SetActive(false);
        rewardCoin500.SetActive(false);
        rewardCoin1000.SetActive(false);
        rewardCoin10000.SetActive(false);
        RewardGem.SetActive(false);
    }
}
