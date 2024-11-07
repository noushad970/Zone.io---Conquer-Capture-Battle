using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoinFromShop : MonoBehaviour
{
    public Button buy200CoinButton, buy1000CoinButton, buy2000CoinButton, buy4000CoinButton;
    public GameObject notEnoughCoin;
    // Start is called before the first frame update
    void Start()
    {
        buy200CoinButton.onClick.AddListener(onClickBuy200Coin);
        buy1000CoinButton.onClick.AddListener (onClickBuy1000Coin);
        buy2000CoinButton.onClick.AddListener(onClickBuy2000Coin);
        buy4000CoinButton.onClick.AddListener(onClickBuy4000Coin);
    }

    void onClickBuy200Coin()
    {

        if (CloudSaveManager.instance.totalGem >= 35)
        {
            //buy
            AudioManager.instance.playCoinSound();
            StaticData.gemData = -35;
            StaticData.SaveGemData = true;
            StaticData.coinData = 200;
            StaticData.SaveCoinData = true;
        }
        else
        {
            //not enough coin
            notEnoughCoin.SetActive(true);
            Debug.Log("Not Enough gem for buy coins");
        }
    }
    void onClickBuy1000Coin()
    {
        if (CloudSaveManager.instance.totalGem >= 125)
        {
            //buy
            AudioManager.instance.playCoinSound();
            StaticData.gemData = -125;
            StaticData.SaveGemData = true;
            StaticData.coinData = 1000;
            StaticData.SaveCoinData = true;
        }
        else
        {
            //not enough coin
            notEnoughCoin.SetActive(true);
            Debug.Log("Not Enough gem for buy coins");
        }
    }
    void onClickBuy2000Coin()
    {
        if (CloudSaveManager.instance.totalGem >= 200)
        {
            //buy
            AudioManager.instance.playCoinSound();
            StaticData.gemData = -200;
            StaticData.SaveGemData = true;
            StaticData.coinData = 2000;
            StaticData.SaveCoinData = true;
        }
        else
        {
            //not enough coin
            notEnoughCoin.SetActive(true);
            Debug.Log("Not Enough gem for buy coins");
        }
    }
    void onClickBuy4000Coin()
    {
        if (CloudSaveManager.instance.totalGem >= 350)
        {
            //buy
            AudioManager.instance.playCoinSound();
            StaticData.gemData = -350;
            StaticData.SaveGemData = true;
            StaticData.coinData = 4000;
            StaticData.SaveCoinData = true;
        }
        else
        {
            //not enough coin
            notEnoughCoin.SetActive(true);
            Debug.Log("Not Enough gem for buy coins");
        }
    }
}
