using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedAndPoisonPowerUpUpgrade : MonoBehaviour
{
    public GameObject[] speedUp;
    public GameObject[] PoisonSpeedDown;
    public Button updateSpeedUpPowerUpButton, updatePoisonPowerUpButton;
    public GameObject notEnoughCoinPanel;
    public TMP_Text SpeedupUpdateAmountText,PoisonUpdateAmountText;
    private void Start()
    {
        updateSpeedUpPowerUpButton.onClick.AddListener(onClickUpdateSpeedUp);
        updatePoisonPowerUpButton.onClick.AddListener(onClickUpdatePoison);
    }
    private void Update()
    {
        setPowerUpDuration();
        setPowerUpDurationPoison();
    }
    void onClickUpdateSpeedUp()
    {
        if (CloudSaveManager.instance.SpeedUpDurationValue == 0)
        {
            if (CloudSaveManager.instance.totalCoin >= 100)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -100;
                StaticData.SaveCoinData = true;
                
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }

        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 1)
        {
            if (CloudSaveManager.instance.totalCoin >= 200)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -200;
                StaticData.SaveCoinData = true;
                
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 2)
        {
            if (CloudSaveManager.instance.totalCoin >= 500)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -500;
                StaticData.SaveCoinData = true;
                
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 3)
        {
            if (CloudSaveManager.instance.totalCoin >= 1000)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -1000;
                StaticData.SaveCoinData = true;
                
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 4)
        {
            if (CloudSaveManager.instance.totalCoin >= 2000)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -2000;
                StaticData.SaveCoinData = true;
                
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 5)
        {
            if (CloudSaveManager.instance.totalCoin >= 5000)
            {
                StaticData.SaveSpeedupDurationUpdate = true;
                StaticData.coinData = -5000;
                StaticData.SaveCoinData = true;
               
            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        
    }
    void onClickUpdatePoison()
    {
        if (CloudSaveManager.instance.PoisonDurationValue == 0)
        {
            if (CloudSaveManager.instance.totalCoin >= 100)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -100;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }

        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 1)
        {
            if (CloudSaveManager.instance.totalCoin >= 200)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -200;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 2)
        {
            if (CloudSaveManager.instance.totalCoin >= 500)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -500;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 3)
        {
            if (CloudSaveManager.instance.totalCoin >= 1000)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -1000;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 4)
        {
            if (CloudSaveManager.instance.totalCoin >= 2000)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -2000;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 5)
        {
            if (CloudSaveManager.instance.totalCoin >= 5000)
            {
                StaticData.SavePoisonDurationUpdate = true;
                StaticData.coinData = -5000;
                StaticData.SaveCoinData = true;

            }
            else
            {
                notEnoughCoinPanel.SetActive(true);
            }
        }

    }
    /// <summary>
    /// remain of powerup poison. Must be completed
    /// </summary>
    void setPowerUpDurationPoison()
    {
        if (CloudSaveManager.instance.PoisonDurationValue == 0)
        {
            PoisonUpdateAmountText.text = "100";
           //
            speedUpAllFalse();
            PoisonSpeedDown[0].SetActive(true);

        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 1)
        {
            PoisonUpdateAmountText.text = "200";
            
            speedUpAllFalse();
            PoisonSpeedDown[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 2)
        {
            PoisonUpdateAmountText.text = "500";
            
            speedUpAllFalse();
            PoisonSpeedDown[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 3)
        {
            PoisonUpdateAmountText.text = "1000";
           
            speedUpAllFalse();
            PoisonSpeedDown[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 4)
        {
            PoisonUpdateAmountText.text = "2000";
           
            speedUpAllFalse();
            PoisonSpeedDown[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 5)
        {
            PoisonUpdateAmountText.text = "5000";
            
            speedUpAllFalse();
            PoisonSpeedDown[5].SetActive(true);
        }
        else if (CloudSaveManager.instance.PoisonDurationValue == 6)
        {
            updateSpeedUpPowerUpButton.gameObject.SetActive(false);
        }
    }
    void setPowerUpDuration()
    {
        if (CloudSaveManager.instance.SpeedUpDurationValue == 0)
        {
            SpeedupUpdateAmountText.text = "100";
            CharacterPowerUp.SpeedUpDuration = 2;
            speedUpAllFalse();
            speedUp[0].SetActive(true);

        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 1)
        {
            SpeedupUpdateAmountText.text = "200";
            CharacterPowerUp.SpeedUpDuration = 3;
            speedUpAllFalse();
            speedUp[1].SetActive(true);
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 2)
        {
            SpeedupUpdateAmountText.text = "500";
            CharacterPowerUp.SpeedUpDuration = 4;
            speedUpAllFalse();
            speedUp[2].SetActive(true);
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 3)
        {
            SpeedupUpdateAmountText.text = "1000";
            CharacterPowerUp.SpeedUpDuration = 5;
            speedUpAllFalse();
            speedUp[3].SetActive(true);
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 4)
        {
            SpeedupUpdateAmountText.text = "2000";
            CharacterPowerUp.SpeedUpDuration = 6;
            speedUpAllFalse();
            speedUp[4].SetActive(true);
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 5)
        {
            SpeedupUpdateAmountText.text = "5000";
            CharacterPowerUp.SpeedUpDuration = 7;
            speedUpAllFalse();
            speedUp[5].SetActive(true);
        }
        else if (CloudSaveManager.instance.SpeedUpDurationValue == 6)
        {
            updateSpeedUpPowerUpButton.gameObject.SetActive(false);
        }
        Debug.Log("Speed up power up duration value:" + CharacterPowerUp.SpeedUpDuration);
    }
    void speedUpAllFalse()
    {
        for(int i=0;i<speedUp.Length;i++)
        {
            speedUp[i].SetActive(false);
        }
    }
}
