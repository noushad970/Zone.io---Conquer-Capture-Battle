using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAndGemAmountShowForBuyChar : MonoBehaviour
{
    public TMP_Text commonCharBuyAmount, EpicCharBuyAmount;
    int coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        showBuyAmount();
        UnlockedEpicAmountShow();
        StartCoroutine(wait8sec());
    }
    IEnumerator wait8sec()
    {
        yield return new WaitForSeconds(7f);

        StaticData.coinData = coin;
        StaticData.SaveCoinData = true;
    }
    // Update is called once per frame
    void Update()
    {
        showBuyAmount();
        UnlockedEpicAmountShow();
    }
    void showBuyAmount()
    {
        if (CloudSaveManager.instance.commonCharVal == 0)
        {
            commonCharBuyAmount.text = "100";
        }
        else if (CloudSaveManager.instance.commonCharVal == 1)
        {
            commonCharBuyAmount.text = "300";
        }
        else if (CloudSaveManager.instance.commonCharVal == 2)
        {
            commonCharBuyAmount.text = "500";
        }
        else if (CloudSaveManager.instance.commonCharVal == 3)
        {
            commonCharBuyAmount.text = "800";
        }
        else if (CloudSaveManager.instance.commonCharVal == 4)
        {
            commonCharBuyAmount.text = "1100";
        }
        else if (CloudSaveManager.instance.commonCharVal == 5)
        {
            commonCharBuyAmount.text = "1500";
        }
        else if (CloudSaveManager.instance.commonCharVal == 6)
        {
            commonCharBuyAmount.text = "2000";
        }
        else if (CloudSaveManager.instance.commonCharVal == 7)
        {
            commonCharBuyAmount.text = "2500";
        }
        
    }
    void UnlockedEpicAmountShow()
    {
        if (CloudSaveManager.instance.epicCharVal == 0)
        {
            EpicCharBuyAmount.text = "19";
        }
        else if (CloudSaveManager.instance.epicCharVal == 1)
        {
            EpicCharBuyAmount.text = "49";
        }
        else if (CloudSaveManager.instance.epicCharVal == 2)
        {
            EpicCharBuyAmount.text = "89";
        }
        else if (CloudSaveManager.instance.epicCharVal == 3)
        {
            EpicCharBuyAmount.text = "120";
        }
        else if (CloudSaveManager.instance.epicCharVal == 4)
        {
            EpicCharBuyAmount.text = "159";
        }
        else if (CloudSaveManager.instance.epicCharVal == 5)
        {
            EpicCharBuyAmount.text = "200";
        }
        else if (CloudSaveManager.instance.epicCharVal == -1)
        {
            EpicCharBuyAmount.text = "9";
        }
    }
}
