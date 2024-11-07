using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacterSkin : MonoBehaviour
{
    public Button buyCommonSkinButton,buyEpicSkinButton,okButton;
    public GameObject[] lockedCommon,lockedEpic,lockedSpecial;
    
    public GameObject notEnoughCoinPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        buyCommonSkinButton.onClick.AddListener(OnClickCommonSkinButton);
        buyEpicSkinButton.onClick.AddListener (OnClickEpicSkinButton);
        okButton.onClick.AddListener(onClickOKButton);
        //onClick
    }
   
    private void Update()
    {
        disableLockLogofromCommonChar();
        disableLockLgoFromEpicChar();
        disableLockLgoFromSpecialChar();
        disableLockLogoFromRearChar();
        
        if (CloudSaveManager.instance.commonCharVal == 9)
        {
            buyCommonSkinButton.gameObject.SetActive(false);
        }
        if (CloudSaveManager.instance.epicCharVal == 7)
        {
            buyEpicSkinButton.gameObject.SetActive(false);
        }
    }
    
    //l0=free,l1=100,l2=300,l3=500,l4=800,l5=1100,l6=1500,l7=2000,l8=2500
    void OnClickCommonSkinButton()
    {
        AudioManager.instance.playTabSound();
        if (CloudSaveManager.instance.commonCharVal == 0)
        {
            if (CloudSaveManager.instance.totalCoin >= 100)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -100;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);}
        }
        else if (CloudSaveManager.instance.commonCharVal == 1)
        {
            if (CloudSaveManager.instance.totalCoin >= 300)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -300;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 2)
        {
            if (CloudSaveManager.instance.totalCoin >= 500)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -500;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 3)
        {
            if (CloudSaveManager.instance.totalCoin >= 800)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -800;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 4)
        {
            if (CloudSaveManager.instance.totalCoin >= 1100)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -1100;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 5)
        {
            if (CloudSaveManager.instance.totalCoin >= 1500)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -1500;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 6)
        {
            if (CloudSaveManager.instance.totalCoin >= 2000)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -2000;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 7)
        {
            if (CloudSaveManager.instance.totalCoin >= 2500)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.coinData = -2500;
                StaticData.SaveCoinData = true;
                StaticData.SaveCommonCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.commonCharVal == 8)
        {
            buyCommonSkinButton.gameObject.SetActive(false);
            Debug.Log("ALL Common Player is Buyed");
        }
    }
    //epic character buy from shop
    //l0=9,l1=19,l2=49,l3=89,l4=120,l5=159,l6=200
    void OnClickEpicSkinButton()
    {
        AudioManager.instance.playTabSound();
        if (CloudSaveManager.instance.epicCharVal == -1)
        {
            if (CloudSaveManager.instance.totalGem >= 9)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -9;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 0)
        {
            if (CloudSaveManager.instance.totalGem >= 19)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -19;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 1)
        {
            if (CloudSaveManager.instance.totalGem >= 49)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -49;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 2)
        {
            if (CloudSaveManager.instance.totalGem >= 89)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -89;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 3)
        {
            if (CloudSaveManager.instance.totalGem >= 119)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -119;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 4)
        {
            if (CloudSaveManager.instance.totalGem >= 159)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -159;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 5)
        {
            if (CloudSaveManager.instance.totalGem >= 200)
            {
                //buy
                AudioManager.instance.playUnlockOrBuySound();
                StaticData.gemData = -200;
                StaticData.SaveGemData = true;
                StaticData.SaveEpicCharData = true;
            }
            else
            {
                //not enough coin
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.epicCharVal == 6)
        {
            buyEpicSkinButton.gameObject.SetActive(false);
            Debug.Log("ALL Epic Player is Buyed");
        }



    }
    void onClickOKButton()
    {
        AudioManager.instance.playTabSound();
        notEnoughCoinPanel.SetActive(false);
    }
    void disableLockLogofromCommonChar()
    {
        for(int i=0;i<= CloudSaveManager.instance.commonCharVal; i++)
        {
            lockedCommon[i].SetActive(false);
        }
        for(int i= CloudSaveManager.instance.commonCharVal+1;i<lockedCommon.Length;i++)
        {
            lockedCommon[i].SetActive(true);
        }
    }
    void disableLockLogoFromRearChar()
    {
    }
    void disableLockLgoFromEpicChar()
    {
        for(int i=0;i<= CloudSaveManager.instance.epicCharVal; i++)
        {
            lockedEpic[i].SetActive(false) ;
        }
        for(int i= CloudSaveManager.instance.epicCharVal ;i<lockedEpic.Length; i++)
        {
            lockedEpic[i].SetActive(true);
        }
    }
    void disableLockLgoFromSpecialChar()
    {
        for (int i = 0; i <= CloudSaveManager.instance.specialCarVal; i++)
        {
            lockedSpecial[i].SetActive(false);
        }
        for (int i = CloudSaveManager.instance.specialCarVal; i < lockedSpecial.Length; i++)
        {
            lockedSpecial[i].SetActive(true);
        }
    }
}
