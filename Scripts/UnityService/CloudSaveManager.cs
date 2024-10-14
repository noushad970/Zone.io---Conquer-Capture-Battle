using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine.UI;

public class CloudSaveManager : MonoBehaviour
{
    // 1= yes,true, 0=no,false
    // Key for storing coins in Cloud Save
    private const string COIN_KEY = "player_coins";
    public Button updateCoinButton;
    public Text playerName;
    // This function initializes Unity Gaming Services and authenticates the player
    private async void Start()
    {
        await InitializeUnityServices();
        updateCoinButton.onClick.AddListener(coinUpdate);
        string st=await AuthenticationService.Instance.GetPlayerNameAsync();
        
        submitNickNameButton.onClick.AddListener(setNickName);
        if (await GetSavednicknameVal() == 0)
        {
            nicknameSetPanel.SetActive(true);
        }
        else {

            playerName.text = st;
            nicknameSetPanel.SetActive(false); 
        }
    }
    
    async void coinUpdate()
    {
        await UpdateCoins(10);
    }

    // Initialize Unity Gaming Services and authenticate the player
    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();  // Or use any other sign-in method if available
                Debug.Log("Player signed in successfully.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error during initialization: {e}");
        }
    }

    // Save player's coins to Unity Cloud Save
    public async Task SaveCoins(int coins)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { COIN_KEY, coins }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Coins saved successfully: {coins}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving coins: {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedCoins()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { COIN_KEY });

            if (savedData.ContainsKey(COIN_KEY))
            {
                int coins = Convert.ToInt32(savedData[COIN_KEY]);
                Debug.Log($"Coins loaded from cloud: {coins}");
                return coins;
            }
            else
            {
                Debug.Log("No saved coins found.");
                return 0;  // Default if no coins are saved
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading coins: {e}");
            return 0;  // Default if there's an error
        }
    }
    public static bool UpdateLeaderBoard;
    public static int coin;
    // Update player's coins (this will overwrite the previous value in Cloud Save)
    public async Task UpdateCoins(int additionalCoins)
    {
        // Fetch the current saved coins
        int currentCoins = await GetSavedCoins();
        int updatedCoins = currentCoins + additionalCoins;
        UpdateLeaderBoard=true;
        coin = additionalCoins;
        // Save the updated coin value back to Cloud Save
        await SaveCoins(updatedCoins);
        
        Debug.Log($"Coins updated. New total: {updatedCoins}");
    }

    ///////////////////// setting nickname functionality
    public InputField nickName;
    public Button submitNickNameButton;
    private const string NICKNAME_KEY = "player_nickname";
    public GameObject nicknameSetPanel;
    string nickname;
    /*private async void Start()
    {
        await UnityServices.InitializeAsync();
        submitNickNameButton.onClick.AddListener(setNickName);
        if (await GetSavednicknameVal() == 0)
        {
            nicknameSetPanel.SetActive(true);
        }
        else { nicknameSetPanel.SetActive(false); }
    }**/
    async void setNickName()
    {
        nickname = nickName.text;
        Debug.Log(nickname + " " + nickName.ToString());
        await SetPlayerDisplayName(nickname);
        await UpdateNicknameVal(1);
    }
    private async Task SetPlayerDisplayName(string playerName)
    {
        try
        {
            await AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
            
            Debug.Log($"Player name set to: {playerName}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to set player name: {e.Message}");
        }
    }


    //save nickname methods
    public async Task SaveNickname(int val)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { NICKNAME_KEY, val }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"nickname saved successfully: {val}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving nickname: {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavednicknameVal()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { NICKNAME_KEY });

            if (savedData.ContainsKey(NICKNAME_KEY))
            {
                int val = Convert.ToInt32(savedData[NICKNAME_KEY]);
                Debug.Log($"nickname loaded from cloud: {val}");
                return val;
            }
            else
            {
                Debug.Log("No saved nickname found.");
                return 0;  // Default if no coins are saved
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading nickname: {e}");
            return 0;  // Default if there's an error
        }
    }
    public async Task UpdateNicknameVal(int val)
    {
        int updatedval = val;

        // Save the updated coin value back to Cloud Save
        await SaveNickname(updatedval);

        Debug.Log($"nickname updated. New total: {updatedval}");
    }

}

