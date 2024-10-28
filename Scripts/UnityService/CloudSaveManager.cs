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
    public static CloudSaveManager instance;
    private const string COIN_KEY = "player_coins";
    private const string GEM_KEY = "player_gems";
    private const string COMMON_CHAR_KEY = "common_character_value";
    private const string REAR_CHAR_KEY = "rear_character_value";
    private const string EPIC_CHAR_KEY = "epic_character_value";
    private const string SPECIAL_CHAR_KEY = "special_character_value";

    private const string Difficulti_Level_KEY = "player_dificulty";
    private const string Score_KEY = "player_Score";
    private const string Unlock_Player_KEY = "player_Unlock";
    public Button updateCoinButton;
    public Text playerName;
    [HideInInspector]
    public int totalCoin = 0, totalGem = 0,commonCharVal,rearCharVal,epicCharVal,specialCarVal;
    // This function initializes Unity Gaming Services and authenticates the player
    private async void Start()
    {
        await InitializeUnityServices();
        string st=await AuthenticationService.Instance.GetPlayerNameAsync();
        await UpdateCoins(10);
        await UpdateGems(100);
        await GetSavedCharCommon();
        await GetSavedCharEpic();
        /*
         * nicknames
         * submitNickNameButton.onClick.AddListener(setNickName);
        if (await GetSavednicknameVal() == 0)
        {
            nicknameSetPanel.SetActive(true);
        }
        else {

            playerName.text = st;
            nicknameSetPanel.SetActive(false); 
        }*/
    }
    private void Awake()
    {
        instance = this;
    }

    private async void Update()
    {
       
        if (StaticData.SaveCoinData)
        {
            StaticData.SaveCoinData = false;
            await UpdateCoins(StaticData.coinData);
            StaticData.coinData = 0;
        }
        if (StaticData.SaveCommonCharData)
        {
            StaticData.SaveCommonCharData= false;
            await UpdateCharCommon();
        }
        if (StaticData.SaveGemData)
        {
            StaticData.SaveGemData = false;
            await UpdateGems(StaticData.gemData);
            StaticData.gemData = 0;
        }
        if (StaticData.SaveEpicCharData)
        {
            StaticData.SaveEpicCharData = false;
            await UpdateCharEpic();
        }
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
            await GetSavedCoins();
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
                totalCoin = coins;
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


   
    // Save player's common character unlocked value to Unity Cloud Save
    public async Task SaveCharCommon(int CommonChar)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { COMMON_CHAR_KEY, CommonChar }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Common Character value saved successfully: {CommonChar}");
            await GetSavedCharCommon();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedCharCommon()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { COMMON_CHAR_KEY });

            if (savedData.ContainsKey(COMMON_CHAR_KEY))
            {
                int CharCommon = Convert.ToInt32(savedData[COMMON_CHAR_KEY]);
                commonCharVal = CharCommon;
                Debug.Log($"CharCommon loaded from cloud: {CharCommon}");

                return CharCommon;
            }
            else
            {
                return 0;  
            }
        }
        catch (Exception e)
        {
            return 0;  
        }
    }

    // Update player's coins (this will overwrite the previous value in Cloud Save)
    public async Task UpdateCharCommon()
    {
        // Fetch the current saved coins
        int currentCharCommon = await GetSavedCharCommon();
        int updatedCharCommon = currentCharCommon + 1;
        
        
        await SaveCharCommon(updatedCharCommon);

    }

    // Save player's Epic character unlocked value to Unity Cloud Save
    public async Task SaveCharEpic(int EpicChar)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { EPIC_CHAR_KEY, EpicChar }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Common Character value saved successfully: {EpicChar}");
            await GetSavedCharEpic();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedCharEpic()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { EPIC_CHAR_KEY });

            if (savedData.ContainsKey(EPIC_CHAR_KEY))
            {
                int CharEpic = Convert.ToInt32(savedData[EPIC_CHAR_KEY]);
                epicCharVal = CharEpic;
                Debug.Log($"CharEpic loaded from cloud: {CharEpic}");

                return CharEpic;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception e)
        {
            return 0;
        }
    }

    // Update player's coins (this will overwrite the previous value in Cloud Save)
    public async Task UpdateCharEpic()
    {
        // Fetch the current saved coins
        int currentCharEpic = await GetSavedCharEpic();
        int updatedCharEpic = currentCharEpic + 1;


        await SaveCharEpic(updatedCharEpic);

    }
    // Save player's gem to Unity Cloud Save
    public async Task SaveGems(int gems)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { GEM_KEY, gems }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Coins saved successfully: {gems}");
            await GetSavedGems();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving gems: {e}");
        }
    }



    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedGems()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { GEM_KEY });

            if (savedData.ContainsKey(GEM_KEY))
            {
                int gems = Convert.ToInt32(savedData[GEM_KEY]);
                totalGem = gems;
                Debug.Log($"gems loaded from cloud: {gems}");

                return gems;
            }
            else
            {
                Debug.Log("No saved gems found.");
                return 0;  // Default if no coins are saved
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading gems: {e}");
            return 0;  // Default if there's an error
        }
    }
    public static int gem;

    // Update player's coins (this will overwrite the previous value in Cloud Save)
    public async Task UpdateGems(int additionalGems)
    {
        // Fetch the current saved coins
        int currentGems = await GetSavedGems();
        int updatedGems = currentGems + additionalGems;
       // UpdateLeaderBoard = true;
        gem = additionalGems;
        // Save the updated coin value back to Cloud Save
        await SaveGems(updatedGems);

        Debug.Log($"Coins updated. New total: {updatedGems}");
    }


    /*
    ///////////////////// setting nickname functionality
    public InputField nickName;
    public Button submitNickNameButton;
    private const string NICKNAME_KEY = "player_nickname";
    public GameObject nicknameSetPanel;
    string nickname;
 
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
    }*/

    // Save player's Score to Unity Cloud Save
    public async Task SaveDifficultyLevel(int DS)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { Difficulti_Level_KEY, DS }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Coins saved successfully: {DS}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving coins: {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedDifficulty()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { Difficulti_Level_KEY });

            if (savedData.ContainsKey(Difficulti_Level_KEY))
            {
                int DF = Convert.ToInt32(savedData[Difficulti_Level_KEY]);
                Debug.Log($"Coins loaded from cloud: {DF}");
                return DF;
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
    public async Task UpdateDifficultyLevel(int levelUpdate)
    {
        // Fetch the current saved coins
        int currentDifficultyLevel = await GetSavedCoins();
        int updatedDifficultyLevel = levelUpdate;
        UpdateLeaderBoard = true;
        
        // Save the updated coin value back to Cloud Save
        await SaveDifficultyLevel(updatedDifficultyLevel);

        Debug.Log($"Coins updated. New total: {updatedDifficultyLevel}");
    }

}

