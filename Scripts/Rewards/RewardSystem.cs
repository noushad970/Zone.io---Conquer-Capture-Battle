using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{
    public TMP_Text countdownText; // Reference to the TextMeshProUGUI for displaying countdown
    public GameObject claimButton; // The button to claim rewards
    public GameObject showTime;
    private const int RewardIntervalHours = 3; // The time interval for rewards (3 hours in this case)
    private DateTime nextClaimTime,nextAdsBoxClaim;
    public TMP_Text countdownTextAds; // Reference to the TextMeshProUGUI for displaying countdown
    public GameObject claimButtonAds; // The button to claim rewards
    public GameObject showTimeAds;
    public TMP_Text countdownTextAds2; // Reference to the TextMeshProUGUI for displaying countdown
    public GameObject claimButtonAds2; // The button to claim rewards
    public GameObject showTimeAds2;

    void Start()
    {
        // Load the last claim time if it exists, otherwise set it to the current time minus the interval
        if (PlayerPrefs.HasKey("LastClaimTime"))
        {
            string lastClaimString = PlayerPrefs.GetString("LastClaimTime");
            nextClaimTime = DateTime.Parse(lastClaimString).AddHours(RewardIntervalHours);
        }
        else
        {
            nextClaimTime = DateTime.Now.AddHours(-RewardIntervalHours);
        }
        //ads box
        if (PlayerPrefs.HasKey("LastClaimTimeAdsBox1"))
        {
            string lastClaimString = PlayerPrefs.GetString("LastClaimTimeAdsBox1");
            nextAdsBoxClaim = DateTime.Parse(lastClaimString).AddHours(RewardIntervalHours);
        }
        else
        {
            nextAdsBoxClaim = DateTime.Now.AddHours(-RewardIntervalHours);
        }
        //ads 2 box
        claimButton.GetComponent<Button>().onClick.AddListener(ClaimReward);
        claimButtonAds.GetComponent<Button>().onClick.AddListener(ClaimRewardAds);
        UpdateUIAds();
        UpdateUI();
        claimButtonAds2.GetComponent<Button>().onClick.AddListener(ClaimRewardAds);
      
    }

    void Update()
    {
        UpdateUI();
        UpdateUIAds();
    }

    private void UpdateUI()
    {
        TimeSpan timeRemaining = nextClaimTime - DateTime.Now;

        if (timeRemaining.TotalSeconds <= 0)
        {
            // Enable the claim button if the reward is available
            claimButton.SetActive(true);
            countdownText.text = "Claim!";
            showTime.SetActive(false);
        }
        else
        {
            // Disable the claim button and show the countdown
            claimButton.SetActive(false);
            showTime.SetActive(true);
            countdownText.text = string.Format("{0:D2}:{1:D2}",
                timeRemaining.Hours, timeRemaining.Minutes);
        }
    }

    public void ClaimReward()
    {
        // Add reward logic here, e.g., increase player coins, items, etc.
        AudioManager.instance.playTabSound();
        // Save the current time as the last claim time and calculate the next claim time
        PlayerPrefs.SetString("LastClaimTime", DateTime.Now.ToString());
        nextClaimTime = DateTime.Now.AddHours(RewardIntervalHours);
        StaticData.gemData = 3;
        StaticData.SaveGemData = true;
        UpdateUI();
    }
    private void UpdateUIAds()
    {
        TimeSpan timeRemaining = nextAdsBoxClaim - DateTime.Now;
        //extra
        //claimButtonAds.SetActive(true);
        //
        if (timeRemaining.TotalSeconds <= 0)
        {
           // Enable the claim button if the reward is available
           claimButtonAds.SetActive(true);
            countdownTextAds.text = "Claim!";
            showTimeAds.SetActive(false);
            claimButtonAds2.SetActive(true);
            countdownTextAds2.text = "Claim!";
            showTimeAds2.SetActive(false);
        }
        else
        {
           // Disable the claim button and show the countdown
            claimButtonAds.SetActive(false);
            showTimeAds.SetActive(true);
            claimButtonAds2.SetActive(false);
            showTimeAds2.SetActive(true);
            countdownTextAds.text = string.Format("{0:D2}:{1:D2}",
                timeRemaining.Hours, timeRemaining.Minutes);

            countdownTextAds2.text = string.Format("{0:D2}:{1:D2}",
                timeRemaining.Hours, timeRemaining.Minutes);
        }
    }

    public void ClaimRewardAds()
    {
        AudioManager.instance.playTabSound();
        PlayerPrefs.SetString("LastClaimTimeAdsBox1", DateTime.Now.ToString());
        nextAdsBoxClaim = DateTime.Now.AddHours(RewardIntervalHours);
        UpdateUIAds();
        RewardedAdsExample.instance.ShowAd();
        //OpenBoxAndGetGift.instance.OpenBox();
    }

    
}
