using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    string _androidGameId = "5725220";
    string _iOSGameId = "5725221";
    [SerializeField] bool _testMode = true;
    private string _gameId;
    public Button testOpenBox;
    void Awake()
    {
        InitializeAds();
    }
    private void Start()
    {
        InstertitialAds.instance.ShowAd();
        InstertitialAds.instance.LoadAd();

        testOpenBox.onClick.AddListener(RewardedAdsExample.instance.ShowAd);
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }

    }


    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}