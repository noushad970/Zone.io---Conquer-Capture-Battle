using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloudSaveManager : MonoBehaviour
{
    // 1= yes,true, 0=no,false
    // Key for storing coins in Cloud Save
    public static CloudSaveManager instance;
    private const string COIN_KEY = "player_coins";
    private const string GEM_KEY = "player_gems";
    private const string COMMON_CHAR_KEY = "common_character_value";
    private const string EPIC_CHAR_KEY = "epic_character_value";
    private const string SPECIAL_CHAR_KEY = "special_character_value";
    private const string SELECT_CHAR_VALUE = "select_character_value";
    private const string SPEED_POWER_UP_VALUE = "select_character_speed_up_value";
    private const string SPEED_POISON_VALUE = "select_character_poison_value";
    private const string TOTAL_MATCHP_PLAYED_VALUE = "total_match_played";
    private const string SELECT_MAP_VAL = "map_value";

    private const string DIFFICULTY_LEVEL_KEY = "player_dificulty";
    
    public Button updateCoinButton;
    public Text playerName;
    private const string FirstPushKeys = "FirstCloudPushs";
    [HideInInspector]
    public int totalCoin = 0, totalGem = 0,commonCharVal,rearCharVal,epicCharVal,specialCarVal,selectedCharValue,difficultyLevel, SpeedUpDurationValue, PoisonDurationValue, totalMatchPlayed,mapValues;
    // This function initializes Unity Gaming Services and authenticates the player
    
    private async void Start()
    {
        //DontDestroyOnLoad(this);
        await InitializeUnityServices();
        string st = await AuthenticationService.Instance.GetPlayerNameAsync();
        if (!PlayerPrefs.HasKey(FirstPushKeys))
        {
            // This block will only run once when the game is played for the first time
            await SaveCoins(0);
            await SaveGems(0);
            await SaveCharValue(100);
            await SaveCharCommon(0);
            await SaveCharEpic(-1);
            await SaveCharSpecial(-1);
            await SaveDifficultyLevel(1);
            await SaveSpeedPowerUpValue(0);
            await SavePoisonPowerUpValue(0);
            await SaveTotalNumberOfMatch(0);
            await SaveMapVal(0);
            // Set a local flag indicating the push has occurred
            PlayerPrefs.SetInt(FirstPushKeys, 1);
            PlayerPrefs.Save();
        }
        await GetSavedCoins();
        await GetSavedCharCommon();
        await GetSavedCharEpic();
        await GetSavedCharSpecial();
        await GetSavedTotalNumberOfMatch();
        await GetSavedGems();
        await GetSavedCharValue();
        await GetSavedDifficulty();
        await GetSavedSpeedPowerUpValue();
        await GetSavedPoisonPowerUpValue();
        
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
    private async void Awake()
    {
        if (instance == null)
        {
            // If not, set this as the Instance and mark it to not be destroyed
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            await GetSavedCoins();
            await GetSavedCharCommon();
            await GetSavedCharEpic();
            await GetSavedCharSpecial();
            await GetSavedTotalNumberOfMatch();
            await GetSavedGems();
            await GetSavedCharValue();
            await GetSavedDifficulty();
            await GetSavedSpeedPowerUpValue();
            await GetSavedPoisonPowerUpValue();
          
            // If an Instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }

    private async void Update()
    {
       
        if (StaticData.SaveCoinData)
        {
            StaticData.SaveCoinData = false;
            await UpdateCoins(StaticData.coinData);
            StaticData.coinData = 0;
            if(SceneManager.GetActiveScene().name=="MenuManager")
            SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveCommonCharData)
        {
            StaticData.SaveCommonCharData= false;
            await UpdateCharCommon();
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveGemData)
        {
            StaticData.SaveGemData = false;
            await UpdateGems(StaticData.gemData);
            StaticData.gemData = 0;
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveEpicCharData)
        {
            StaticData.SaveEpicCharData = false;
            await UpdateCharEpic();
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveSpecialCharData)
        {
            StaticData.SaveSpecialCharData = false;
            await UpdateCharSpecial();
            SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveCharacterValue)
        {
            StaticData.SaveCharacterValue = false;
            if (SceneManager.GetActiveScene().name == "MenuManager")
                await UpdateCharacterValue(StaticData.CharacterValue);
        }
        if (StaticData.SaveDifficultyLevelData)
        {
            StaticData.SaveDifficultyLevelData = false;
            await UpdateDifficultyLevel(StaticData.DifficultyLevelData);
        }
        if (StaticData.SaveSpeedupDurationUpdate)
        {
            StaticData.SaveSpeedupDurationUpdate=false;
            await UpdateSpeedPowerUpValue();
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SavePoisonDurationUpdate)
        {
            StaticData.SavePoisonDurationUpdate=false;
            await UpdatePoisonPowerUpValue();
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
        }
        if (StaticData.SaveTotalplayMatchCount)
        {
            StaticData.SaveTotalplayMatchCount = false;
            await UpdateTotalNumberOfMatch();
        }
        if (StaticData.SaveMapVal)
        {
            StaticData.SaveMapVal = false;
            await UpdateMapValue(StaticData.mapVal);
           
            if (SceneManager.GetActiveScene().name == "MenuManager")
                SplashScreenManager.Instance.showLoadingBar();
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
      

        //save special character data to cloud
        public async Task SaveCharSpecial(int SpecialChar)
        {
            try
            {
                var data = new Dictionary<string, object>
                {
                    { SPECIAL_CHAR_KEY, SpecialChar }
                };

                await CloudSaveService.Instance.Data.ForceSaveAsync(data);
                Debug.Log($"Common Character value saved successfully: {SpecialChar}");
                await GetSavedCharSpecial();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error saving : {e}");
            }
        }

        // Fetch player's saved coins from Unity Cloud Save
        public async Task<int> GetSavedCharSpecial()
        {
            try
            {
                var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { SPECIAL_CHAR_KEY });

                if (savedData.ContainsKey(SPECIAL_CHAR_KEY))
                {
                    int CharSpecial = Convert.ToInt32(savedData[SPECIAL_CHAR_KEY]);
                    specialCarVal = CharSpecial;
                    Debug.Log($"CharEpic loaded from cloud: {CharSpecial}");

                    return CharSpecial;
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
        public async Task UpdateCharSpecial()
        {
            // Fetch the current saved coins
            int currentCharSpecial = await GetSavedCharSpecial();
            int updatedCharSpecial = currentCharSpecial + 1;


            await SaveCharSpecial(updatedCharSpecial);

        }
    
    
    //save character value to select character on game data to cloud
    public async Task SaveCharValue(int CharValue)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { SELECT_CHAR_VALUE, CharValue }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Common Character value saved successfully: {CharValue}");
            await GetSavedCharValue();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }
    public static bool readyToShowCharacterInMenu;
    // Fetch player's saved character value from Unity Cloud Save
    public async Task<int> GetSavedCharValue()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { SELECT_CHAR_VALUE });

            if (savedData.ContainsKey(SELECT_CHAR_VALUE))
            {
                int CharValue = Convert.ToInt32(savedData[SELECT_CHAR_VALUE]);
                selectedCharValue = CharValue;
                Debug.Log($"CharVal loaded from cloud: {selectedCharValue   }");
                readyToShowCharacterInMenu= true;
                return CharValue;
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
    public async Task UpdateCharacterValue(int CharValue)
    {
        // Fetch the current saved coins
        int currentCharValue = await GetSavedCharValue();
        int updatedCharValue =  CharValue;
        // UpdateLeaderBoard = true;
      
        // Save the updated coin value back to Cloud Save
        await SaveCharValue(updatedCharValue);

        Debug.Log($"Coins updated. New total: {updatedCharValue}");
    }
    
    //save data for speed up powerup
    public async Task SaveSpeedPowerUpValue(int speedUpVal)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { SPEED_POWER_UP_VALUE, speedUpVal }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"speedUpVal value saved successfully: {speedUpVal}");
            await GetSavedSpeedPowerUpValue();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }
    // Fetch player's saved character value from Unity Cloud Save
    public async Task<int> GetSavedSpeedPowerUpValue()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { SPEED_POWER_UP_VALUE });

            if (savedData.ContainsKey(SPEED_POWER_UP_VALUE))
            {
                int speedUpVal = Convert.ToInt32(savedData[SPEED_POWER_UP_VALUE]);
                SpeedUpDurationValue = speedUpVal;
                Debug.Log($"speedUpVal loaded from cloud: {speedUpVal}");
                return speedUpVal;
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
    public async Task UpdateSpeedPowerUpValue()
    {
        // Fetch the current saved coins
       int getSpeedUpVal= await GetSavedSpeedPowerUpValue();
        int updatedSpeedUp = getSpeedUpVal+1;
        // UpdateLeaderBoard = true;
       
        // Save the updated coin value back to Cloud Save
        await SaveSpeedPowerUpValue(updatedSpeedUp);
        Debug.Log($"Coins updated. New total: {updatedSpeedUp}");
    }
    

    //save data for speed up powerup
    public async Task SavePoisonPowerUpValue(int poisonVal)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { SPEED_POISON_VALUE, poisonVal }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"speedUpVal value saved successfully: {poisonVal}");
            await GetSavedPoisonPowerUpValue();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }
    // Fetch player's saved character value from Unity Cloud Save
    public async Task<int> GetSavedPoisonPowerUpValue()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { SPEED_POISON_VALUE });

            if (savedData.ContainsKey(SPEED_POISON_VALUE))
            {
                int PoisonVal = Convert.ToInt32(savedData[SPEED_POISON_VALUE]);
                PoisonDurationValue = PoisonVal;
                Debug.Log($"speedUpVal loaded from cloud: {PoisonVal}");
                return PoisonVal;
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
    public async Task UpdatePoisonPowerUpValue()
    {
        // Fetch the current saved coins
        int getPoisonVal = await GetSavedPoisonPowerUpValue();
        int updatedPoisonVal = getPoisonVal + 1;
        

        // Save the updated coin value back to Cloud Save
        await SavePoisonPowerUpValue(updatedPoisonVal);

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



    // Save player's Difficulty Level to Unity Cloud Save
    public async Task SaveDifficultyLevel(int DS)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { DIFFICULTY_LEVEL_KEY, DS }
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
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { DIFFICULTY_LEVEL_KEY });

            if (savedData.ContainsKey(DIFFICULTY_LEVEL_KEY))
            {
                int DF = Convert.ToInt32(savedData[DIFFICULTY_LEVEL_KEY]);
                difficultyLevel = DF;
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
    public async Task UpdateDifficultyLevel(int difLevel)
    {
        // Fetch the current saved coins
        int currentLevel = await GetSavedGems();
        int updatedLevel = difLevel;
        // UpdateLeaderBoard = true;
        difficultyLevel = difLevel;
        // Save the updated coin value back to Cloud Save
        await SaveDifficultyLevel(updatedLevel);

        Debug.Log($"Coins updated. New total: {updatedLevel}");
    }
    //update total play game match
    public async Task SaveTotalNumberOfMatch(int matchPlayed)
    {
        try
        {
            var data = new Dictionary<string, object>
                {
                    { TOTAL_MATCHP_PLAYED_VALUE, matchPlayed }
                };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"total match played number saved successfully: {matchPlayed}");
            await GetSavedTotalNumberOfMatch();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving : {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedTotalNumberOfMatch()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { TOTAL_MATCHP_PLAYED_VALUE });

            if (savedData.ContainsKey(TOTAL_MATCHP_PLAYED_VALUE))
            {
                int matchPlayed = Convert.ToInt32(savedData[TOTAL_MATCHP_PLAYED_VALUE]);
                totalMatchPlayed = matchPlayed;
                Debug.Log($"CharEpic loaded from cloud: {matchPlayed}");

                return matchPlayed;
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
    public async Task UpdateTotalNumberOfMatch()
    {
        // Fetch the current saved coins
        int currentmatchPlayed = await GetSavedTotalNumberOfMatch();
        int updatedmatchPlayed = currentmatchPlayed + 1;


        await SaveTotalNumberOfMatch(updatedmatchPlayed);

    }
    //save map value on cloud store

    public async Task SaveMapVal(int MV)
    {
        try
        {
            var data = new Dictionary<string, object>
            {
                { SELECT_MAP_VAL, MV }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Map value saved successfully: {MV}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving map value: {e}");
        }
    }

    // Fetch player's saved coins from Unity Cloud Save
    public async Task<int> GetSavedMapVal()
    {
        try
        {
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { SELECT_MAP_VAL });

            if (savedData.ContainsKey(SELECT_MAP_VAL))
            {
                int MV = Convert.ToInt32(savedData[SELECT_MAP_VAL]);
                mapValues = MV;
                Debug.Log($"map value loaded from cloud: {MV}");
                return MV;
            }
            else
            {
                return 0;  // Default if no coins are saved
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading map value: {e}");
            return 0;  // Default if there's an error
        }
    }
    public async Task UpdateMapValue(int mapVals)
    {
        // Fetch the current saved coins
        int currentMapVal = await GetSavedMapVal();
        int updatedMapVal = mapVals;
        // UpdateLeaderBoard = true;
        difficultyLevel = mapVals;
        // Save the updated coin value back to Cloud Save
        await SaveMapVal(updatedMapVal);

        Debug.Log($"map value updated: {updatedMapVal}");
    }


}

